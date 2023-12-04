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
    [SerializeField] bool _checkGround;
    [SerializeField] float _timerValue;

    private Vector3 _Velocity;
    private float _gravity = -9.81f;
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
    void Update()
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
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        Vector3 m = value.ReadValue<Vector3>();
        _moveX = m.x;
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        if(_checkGround == true && _groundTime == false)
        {
            _groundTime = true;
            _Velocity.y = Mathf.Sqrt(_jump * -3.0f * _gravity);
            
        }
    }

    void Move() //Movimento do Persoangem
    {
        _character.Move(new Vector3(_moveX, _character.velocity.y, _character.velocity.z) * _speed * Time.deltaTime);
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
        _Velocity.y += _gravity * Time.deltaTime;
        _character.Move(_Velocity * Time.deltaTime);
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
        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;
        }
    }
}