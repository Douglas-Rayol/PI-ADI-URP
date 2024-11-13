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
    [SerializeField] public GameObject _particula;

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

    [Header("Variavel para o Coyote do Player")]
    [SerializeField] int _coyote;
    [SerializeField] bool _sinalCoyote;
    [SerializeField] float _timeCoyote;
    float _salvaTimeCoyote;
    

    void Awake()
    {

        _batalhaControle = Camera.main.GetComponent<BatalhaControle>();
        _menuBatalha = Camera.main.GetComponent<MenuBatalha>();

    }

    void Start()
    {

        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        _salvaTimeCoyote = _timeCoyote;
        
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
            CoyoteTime();

            _hpHud.fillAmount = (float) _vidaMin / _vidaMax;

            float porcentagemVida = ((float) _vidaMin / _vidaMax) * 100;

            _porcentagemTxt.text = "" + porcentagemVida + "%";
            

            if(_vidaMin <= 0)
            {
                StartCoroutine(Morte());
                PlayerPrefs.SetInt("Player", _tipo);
                _porcentagemTxt.text = "0%";
                _menuBatalha.StartCoroutine("AtivaMenu", 3f);
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
        if(value.performed && _checkGround && !_batalhaControle._pausaJogo)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _pulo, _rb.velocity.z);

            _sinalCoyote = false;
        }

        //Pulo com Coyote
        else if(value.performed && _coyote == 1)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _pulo, _rb.velocity.z);
            _sinalCoyote = false;
        }
    }

    public void SetAtaque(InputAction.CallbackContext value) //PlayerInput para o Tiro do Jogador
    {
        if(value.performed && !_batalhaControle._pausaJogo)
        {
            _anim.SetLayerWeight(1, 1);
            _anim.SetTrigger("Ataque");
        }
    }

    public void SetStart(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            if(!_menuBatalha._startMenu)
            {
                PlayerPrefs.DeleteKey("Player");
                _menuBatalha.StartCoroutine("AtivaMenu", 0);
                _menuBatalha._playerVenceu.text = "Pause";
                _menuBatalha._startMenu = true;
            }
            else
            {
                _menuBatalha.StartCoroutine("DesativaMenu");
                _menuBatalha._startMenu = false;
            }


            
        }
    }
    
    public void PlayerMovimento() //Aqui faz todo o movimento do Player
    {     
        _rb.velocity = new Vector3(_move.x * _speed, _rb.velocity.y, _rb.velocity.z);        
    }

    
    private void GravidadePlayer() //Aqui controla a gravidade do Player
    {
        if(!_checkGround)
        {
            _rb.AddForce(Vector3.down * _gravidade);
        }
        
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

            _sinalCoyote = true;

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

    IEnumerator Morte()
    {
        GetComponent<SkinPlayer>()._skinPadrao.SetActive(false);
        yield return new WaitForSeconds(.2f);
        _particula.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        _particula.gameObject.SetActive(false);
        transform.root.gameObject.SetActive(false);
        
    }

    private void CoyoteTime()
    {
        if(_sinalCoyote && !_checkGround)
        {
            _timeCoyote -= Time.deltaTime;

            if(_timeCoyote > 0)
            {
                _coyote = 1;
            }
            else
            {
                _sinalCoyote = false;
            }
        }
        else
        {
            _timeCoyote = _salvaTimeCoyote;
            _coyote = 0;
        }
    }
    



}   
