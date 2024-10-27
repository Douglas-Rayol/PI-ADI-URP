using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Cinemachine.Utility;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerBatalha : MonoBehaviour
{
    [Header("Componente Globais")]
    [SerializeField] BatalhaControle _batalhaControle;
    [SerializeField] MenuBatalha _menuBatalha;

    [Header("Componentes")]
    [SerializeField] public Rigidbody _rb;
    [SerializeField] public Animator _anim;
    [SerializeField] public Vector3 _move;
    [SerializeField] public SpriteRenderer _sprite;
    [SerializeField] Image _hpHud;
    [SerializeField] TextMeshProUGUI _porcentagemTxt;

    [Header("Tipo do Player")]
    [SerializeField] public int _tipo;

    [Header("Variaveis para Movimentações")]
    [SerializeField] public float _speed;
    [SerializeField] public float _gravidade;
    [SerializeField] public float _pulo;

    [Header("Variaveis para Checar o Chao")]
    [SerializeField] bool _checkGround;
    [SerializeField] int _groundCount;

    [Header("Variaveis para Suavizar a Animacao")]
    [SerializeField] private float smoothInputX;
    [SerializeField] private float velocityX;

    [Header("Verifica Direcao do Tiro")]
    [SerializeField] public bool _direcaoSpriteFlip;
    [SerializeField] public bool _inverterDirecao;

    [Header("Variavel da Vida do Jogador")]
    [SerializeField] public float _vidaMin;
    [SerializeField] public float _vidaMax;

    void Awake()
    {

        _batalhaControle = Camera.main.GetComponent<BatalhaControle>();
        _menuBatalha = Camera.main.GetComponent<MenuBatalha>();

    }

    void Start()
    {

        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {

        if(!_batalhaControle._pausaJogo)
        {
            PlayerMovimento();
            GravidadePlayer();
            AnimacaoPlayer();
            FlipPlayer();
            VerificaDirecaoTiro();

            _hpHud.fillAmount = (float) _vidaMin / _vidaMax;

            float porcentagemVida = ((float) _vidaMin / _vidaMax) * 100;

            _porcentagemTxt.text = "" + porcentagemVida + "%";
            

            if(_vidaMin <= 0)
            {
                transform.root.gameObject.SetActive(false);
                PlayerPrefs.SetInt("Player", _tipo);
                _menuBatalha.StartCoroutine("AtivaMenu");

            }
        }


    }

    
    public void SetMove(InputAction.CallbackContext value) //PlayerInput para o Movimento do Player
    {
        if(!_inverterDirecao) //Inverte o Controle se tiver com PowerUp de Inverter
        {
            _move = value.ReadValue<Vector3>().normalized;
        }
        else
        {
            _move = -value.ReadValue<Vector3>().normalized;
        }
        
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
    
    public void PlayerMovimento() //Aqui faz todo o movimento do Player
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
        _sprite.flipX = !_direcaoSpriteFlip;

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
           _direcaoSpriteFlip = true;
        }
        else if(transform.eulerAngles.y == 270)
        {
            _direcaoSpriteFlip = false;
        }        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            _groundCount++;

            _checkGround = true;

            _anim.SetBool("Jump", false);

        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {            
            _groundCount--;

            if(_groundCount == 0)
            {
                _checkGround = false;

                _anim.SetBool("Jump", true);
            }
            
        }
    }

    //Treme o Controle
    //GetComponent<VibrationController>().Vibrar(.5f, 1f);



}   
