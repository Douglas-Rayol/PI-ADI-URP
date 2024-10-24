using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerBatalha : MonoBehaviour
{
    
    [Header("Componentes")]
    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _anim;
    [SerializeField] Vector3 _move;
    [SerializeField] Transform _posTiro;
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] Image _hpHud;

    [Header("Variaveis para Movimentações")]
    [SerializeField] float _speed;
    [SerializeField] float _gravidade;
    [SerializeField] float _pulo;

    [Header("Variaveis para Checar o Chao")]
    [SerializeField] bool _checkGround;

    [Header("Variaveis para Suavizar a Animacao")]
    [SerializeField] private float smoothInputX;
    [SerializeField] private float velocityX;

    [Header("Verifica Direcao do Tiro")]
    [SerializeField] bool _direcaoVerdadeira;

    [Header("Variavel da Vida do Jogador")]
    [SerializeField] int _vidaMin;
    [SerializeField] int _vidaMax;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        PlayerMovimento();
        GravidadePlayer();
        AnimacaoPlayer();
        FlipPlayer();
        VerificaDirecaoTiro();

        _hpHud.fillAmount = (float) _vidaMin / _vidaMax;

        if(_vidaMin <= 0)
        {
            transform.root.gameObject.SetActive(false);
        }

    }

    
    public void SetMove(InputAction.CallbackContext value) //PlayerInput para o Movimento do Player
    {
        _move = value.ReadValue<Vector3>().normalized;
    }

    
    public void SetPulo(InputAction.CallbackContext value) //PlayerInput para o Pulo do Player
    {
        if(value.performed && _checkGround)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _pulo, _rb.velocity.z);
        }
    }

    public void SetAtaque(InputAction.CallbackContext value) //PlayerInput para o Tiro do Jogador
    {
        if(value.performed)
        {
            _anim.SetLayerWeight(2, 1);
            _anim.SetTrigger("Ataque");
        }
    }
    
    private void PlayerMovimento() //Aqui faz todo o movimento do Player
    {
        _rb.velocity = new Vector3(_move.x * _speed, _rb.velocity.y, _rb.velocity.z);
    }

    
    private void GravidadePlayer() //Aqui controla a gravidade do Player
    {
        _rb.AddForce(Vector3.down * _gravidade);
    }

    
    private void AnimacaoPlayer() //Aqui controla a animação do Player
    {
        _anim.SetFloat("InputX", smoothInputX);

        smoothInputX = Mathf.SmoothDamp(smoothInputX, _move.x, ref velocityX, 0.1f);
    }

    private void FlipPlayer() //Aqui controla o Flip do Jogador
    {
        _sprite.flipX = !_direcaoVerdadeira;

        if(_move.x > 0.1f)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if(_move.x < -0.1f)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
    }

    private void VerificaDirecaoTiro() //Verifica se o tiro tá na direção que o jogador olhou
    {
        if(transform.eulerAngles.y == 90)
        {
            
           _direcaoVerdadeira = true;
        }
        else if(transform.eulerAngles.y == 270)
        {
            _direcaoVerdadeira = false;
        }        
    }

    private void TiroDoPlayer()
    {

        GameObject Tiro = ObjectPool.SharedInstance.GetPooledObject();
        if (Tiro != null)
        {
            Tiro.transform.position = _posTiro.transform.position;
            Tiro.SetActive(true);

            //Verifica a Direcao do Tiro
            if (_direcaoVerdadeira == true)
            {
                Tiro.gameObject.GetComponent<TiroPadrao>()._direction = 1;

            }

            else if (_direcaoVerdadeira == false)
            {
                Tiro.gameObject.GetComponent<TiroPadrao>()._direction = -1;
            }

        }

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            
            _checkGround = true;

            _anim.SetBool("Jump", false);

        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;

            _anim.SetBool("Jump", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AtaquePlayer"))
        {
            _vidaMin--; //Retira a vida do Jogador
            other.gameObject.SetActive(false); //Destroi o tiro

            //Animacao de Dano
            _rb.DOMove(new Vector2(_rb.position.x, 1f), .1f, false);
        }
    }

}   
