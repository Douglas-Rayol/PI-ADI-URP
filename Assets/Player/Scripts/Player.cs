using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] CharacterController _character;
    [SerializeField] float _speed;
    [SerializeField] float _jump;
    [SerializeField] float _timerValue;

    [SerializeField] bool _checkGround;
    [SerializeField] bool _isJumping;

    [SerializeField] Vector3 _velocity;
    [SerializeField] Vector3 _move;

    [SerializeField] float _gravity;
    private float _animacao;
    
    private bool _rotacao;
    public bool _groundTime;
    float _time;

    Animator _anim;
    int _runHash = Animator.StringToHash("Andando");
    int _jumpHash = Animator.StringToHash("Jump");

    [SerializeField] bool _ativaMovimento;

    public Image _image;
    public Color[] _color;


    // Start is called before the first frame update
    void Start()
    {


        _time = _timerValue;
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _checkGround = _character.isGrounded;




        if (_ativaMovimento == true)
        {
            Move();
            AnimacaoPlayer();
            _character.Move(_velocity * Time.deltaTime); //Coloquei aqui pra puxar o geral. Tudo que passa no _velocity vem pra esse character.move! Antes, estava só na gravidade. (Jotapê)
        }
        else
        {
            
            _velocity.x = 0f;
            _anim.SetFloat(_runHash, 0);
        }

        
        Gravity();



        if (_groundTime)
        {
            _time -= Time.deltaTime;
            if (_time < 0)
            {
                _groundTime = false;
                _time = _timerValue;
            }
        }

       

    }

    public void SetMove(InputAction.CallbackContext value)
    {
     
        _move = value.ReadValue<Vector3>();

    }

    public void SetJump(InputAction.CallbackContext value)
    {
        if(value.performed && _checkGround == true && _ativaMovimento ==  true)
        {
            _groundTime = true;
            _velocity.y = _jump; //Novo Jump, tentei de tudo e só funcionou assim, não me pergunte o por quê kkk (Jotapê)
        }
    }

    void Move() //Movimento do Persoangem
    {

        _velocity = new Vector3(_move.x * _speed, _velocity.y, _velocity.z); //Modifiquei aqui, deixei mais limpo o código (Jotapê)
        _animacao = Mathf.Abs(_move.x);

        if (_move.x > 0 && _rotacao)
        {
            Flip();
        }

        else if (_move.x < 0 && !_rotacao)
        {
            Flip();
        }
    }

    void AnimacaoPlayer()
    {
        _anim.SetFloat(_runHash, _animacao);
        //_anim.SetBool(_runHash, _moveX != 0);
        _anim.SetBool(_jumpHash, _checkGround);
        _anim.SetBool("GroundCheck", _checkGround);
        _anim.SetFloat("VelocidadeY", _character.velocity.y);

    }


    void Gravity()
    {
        if(_checkGround == true && _isJumping == true) //Se o _isJumping for verdadeiro (Jotapê)
        {
            _velocity.y = 0f;
        }
        
        if(_checkGround == false && _isJumping == false) //Se o _isJumping for falso (Jotapê)
        {
            _velocity.y += _gravity;
        }

    }

    private void Flip() // Flip do Personagem (Direita e Esquerda)
    {
        _rotacao = !_rotacao;

        Vector3 theScale = transform.localEulerAngles;
        theScale.y *= -1;
        transform.localEulerAngles = theScale;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Inimigo"))
        {
            transform.DOMove(other.GetComponent<Mordida>()._pos.position, .5f);
            StartCoroutine(TempoControle(other.GetComponent<Mordida>()._pos.position, other.GetComponent<Mordida>()._pos2.position));//Sistema de Courotine para travar o player ao levar dano. (Jotapê)
        }
    }

    IEnumerator TempoControle(Vector3 value, Vector3 value2)
    {
        
        _ativaMovimento = false;
        //transform.position = value;
        yield return new WaitForSeconds(0.5f);
        transform.position = value;
        _image.DOColor(_color[0], 0.5f);
        yield return new WaitForSeconds(1f);
        transform.position = value2;
        yield return new WaitForSeconds(1f);
        _image.DOColor(_color[1], 0.5f);
        _ativaMovimento = true;

    }

}