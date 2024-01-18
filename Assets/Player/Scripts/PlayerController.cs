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

    [SerializeField] Transform _PosPlayer;
    [SerializeField] float _g2;
    [SerializeField] bool _checkGround;
    [SerializeField] int _groundTest;

    bool _rotacao;
    private float _animacao;
    int _runHash = Animator.StringToHash("Andando");
    int _jumpHash = Animator.StringToHash("Jump");
    int _rumJump = Animator.StringToHash("RunJump");
    [SerializeField] bool _plataforma;


    public float minimum = -1.0F;
    public float maximum = 1.0F;
    static float t = 0.0f;



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
        _anim.SetFloat("InputX", _animacao);

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

        //if (value.performed && _checkGround == true && _plataforma == true)
        //{
        //    _anim.SetBool("RunJump", true); 
        //}
        //if (value.performed && _checkGround == true && _plataforma == true)
        //{
        //    _anim.SetBool("RunJump", false);
        //}
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
            _groundTest++;
            _checkGround = true;
            _anim.SetLayerWeight(1, 0);
            _anim.SetBool("Jump", false);
        }
        if (other.gameObject.CompareTag("Plataforma"))
        {
            _plataforma = true;
            transform.SetParent(other.transform);// traformando o Player em parente da plataforma (Ivo)
            _checkGround = true;
            _anim.SetLayerWeight(1, 0);
            _anim.SetBool("Jump", false);

        }
    }

    private void OnTriggerExit(Collider other)  //Jotapê
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _groundTest--;
            if(_groundTest == 0)
            {
                _checkGround = false;
                _anim.SetBool("Jump", true);
                _anim.SetLayerWeight(1, 1);
            }
            
        }
        if (other.gameObject.CompareTag("Plataforma"))
        {
           _plataforma = false;
            transform.SetParent(_PosPlayer.transform); //movimento de plataforma (Ivo)
            _checkGround = false;
            _anim.SetBool("Jump", true);
            _anim.SetLayerWeight(1, 1);

        }
    }


}
