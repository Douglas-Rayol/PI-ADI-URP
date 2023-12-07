using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] CharacterController _character;
    [SerializeField] float _speed;
    [SerializeField] float _jump;
    [SerializeField] float _timerValue;

    [SerializeField] bool _checkGround;
    [SerializeField] bool _isJumping; //Variavel necessaria para o pulo. (Jotape)

    private Vector3 _Velocity;
    [SerializeField] float _gravity = -9.81f;
    private float _animacao;
    private float _moveX;
    private bool _rotacao;
    public bool _groundTime;
    float _time;

    Animator _anim;
    int _runHash = Animator.StringToHash("Andando");
    int _jumpHash = Animator.StringToHash("Jump");

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
      
        Move();
        Gravity();
        _anim.SetBool(_runHash, _moveX != 0);
        _anim.SetBool(_jumpHash, _checkGround);
        _anim.SetBool("GroundCheck", _checkGround);
        _anim.SetFloat("VelocidadeY", _character.velocity.y);

        if (_groundTime)
        {
            _time -= Time.deltaTime;
            if (_time < 0)
            {
                _groundTime = false;
                _time = _timerValue;
            }
        }


        _character.Move(_Velocity * Time.deltaTime); //Coloquei aqui pra puxar o geral. Tudo que passa no _Velocity vem pra esse character.move! Antes, estava só na gravidade. (Jotapê)
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        Vector3 m = value.ReadValue<Vector3>();
        _moveX = m.x;
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        if(_checkGround == true)
        {
            _groundTime = true;
            _Velocity.y = Mathf.Sqrt(_jump * -2.0f * _gravity);
        }
    }

    void Move() //Movimento do Persoangem
    {
        _character.Move(new Vector3(_moveX * _speed * Time.deltaTime, _character.velocity.y, _character.velocity.z));
        _anim.SetFloat("Andando", _animacao);
        _animacao = Mathf.Abs(_moveX);

        if (_moveX > 0 && _rotacao)
        {
            Flip();
        }

        else if (_moveX < 0 && !_rotacao)
        {
            Flip();
        }
    }

    void Gravity()
    {

        if(_checkGround == true && _isJumping == true) //Se o _isJumping for verdadeiro, ele vai ativar essa gravidade. (Jotape)
        {
            _Velocity.y = -0f;
        }
        
        if (_checkGround == false && _isJumping == false) //Se o _isJumping for falso ele vai ativar a gravidade no ar pra puxar o player. (Jotape)
        {
            _Velocity.y += _gravity * Time.deltaTime;
        }

        
        
    }

    private void Flip() // Flip do Personagem (Direita e Esquerda)
    {
        _rotacao = !_rotacao;

        Vector3 theScale = transform.localEulerAngles;
        theScale.y *= -1;
        transform.localEulerAngles = theScale;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            _checkGround = true;
            _isJumping = true;

        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;
            _isJumping = false;
        }
    }
    public void teste() //adicionmento de script animetion (ideia do ivo)
    {
        Debug.Log("Atira");
    }
}