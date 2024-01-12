using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _anim;
    [SerializeField] Vector3 _move;

    [SerializeField] float _speed;
    [SerializeField] float _jump;
    [SerializeField] float _runJump;
    [SerializeField] float _gravidade;

    bool _rotacao;
    [SerializeField] bool _checkGround;
    [SerializeField] bool _isRunJump;
    
    private float _animacao;
    int _runHash = Animator.StringToHash("Andando");
    int _jumpHash = Animator.StringToHash("Jump");
    int _rumJump = Animator.StringToHash("Run-Jump");
    [SerializeField] bool _plataforma;

    [SerializeField] float _g2;

    [SerializeField] Transform _PosPlayer;
 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _g2 = _rb.velocity.y;
        Movimento();
        AnimacaoPlayer();
        if (_plataforma)
        {

        }
        else
        {
           Gravidade();
        }
   

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
        //_anim.SetBool(_runHash, _move.x != 0);
        _anim.SetBool(_jumpHash, _checkGround);
        _anim.SetBool(_rumJump, _checkGround);
        _anim.SetBool("GroundCheck", _checkGround);
        _anim.SetFloat("VelocidadeY", _rb.velocity.y);

    }

    public void SetMove(InputAction.CallbackContext value) //Jotapê
    {

        _move = value.ReadValue<Vector3>();

    }

    void Movimento() //Jotapê
    {
        _rb.velocity = new Vector3(_move.x * _speed, _rb.velocity.y, _rb.velocity.z); 
        _animacao = Mathf.Abs(_move.x); 
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        if (value.performed && (_checkGround || _plataforma)) //Jotapê
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _jump, _rb.velocity.z);
        }
    }

    void Gravidade()  //Jotapê
    {
        _rb.AddForce(Vector3.down * _gravidade);
    }

    private void Flip() // Flip do Personagem (Direita e Esquerda)
    {
        _rotacao = !_rotacao;

        Vector3 theScale = transform.eulerAngles; // orientacao do pai (Plataforma) para o filho (Player)(Ivo)
        theScale.y *= -1;
        transform.eulerAngles = new Vector3(0, theScale.y, 0);
    }


    private void OnTriggerEnter(Collider other)  //Jotapê
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _checkGround = true;
        }
        if (other.gameObject.CompareTag("Plataforma"))
        {
            _plataforma = true;
            transform.SetParent(other.transform);// traformando o Player em parente da plataforma (Ivo)
            _checkGround = true;
          
        }
    }

    private void OnTriggerExit(Collider other)  //Jotapê
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;
        }
        if (other.gameObject.CompareTag("Plataforma"))
        {
           _plataforma = false;
            transform.SetParent(_PosPlayer.transform); //movimento de plataforma (Ivo)
            _checkGround = false;

        }
    }


}
