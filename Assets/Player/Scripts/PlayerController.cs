using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    //Vida do Jogador
    [SerializeField] public int _vida = 3;
    [SerializeField] bool _dano;
    [SerializeField] GameObject _PlayerHit;

    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _anim;
    [SerializeField] public Vector3 _move;
    [SerializeField] Transform _raycasGround;

    [SerializeField] float _speed;
    [SerializeField] float _jump;
    [SerializeField] float _gravidade;
    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    public bool _ativadorMovimento;

    RaycastHit teto;

    [SerializeField] Transform _PosPlayer;
    [SerializeField] float _g2;
    [SerializeField] bool _checkGround;
    [SerializeField] int _groundCount;

    bool _rotacao;
    private float _animacao;
    int _runHash = Animator.StringToHash("Andando");
    int _jumpHash = Animator.StringToHash("Jump");
    int _rumJump = Animator.StringToHash("RunJump");
    [SerializeField] bool _plataforma;

    [Header("Sistema de Orientação de Objeto")]
    [SerializeField] UnityEvent _OnEnter;
    [SerializeField] UnityEvent _OnExit;
    [SerializeField] private bool _dentroPlataforma;

    //Posicão do Tiro
    public Transform _posTiro;
    private bool _direcaoVerdadeira;
    public bool _ativaTiro;



    // Start is called before the first frame update
    void Start()
    {

        _ativaTiro = true;
        _direcaoVerdadeira = true;
        _ativadorMovimento = true;
        _dano = true;
        _dentroPlataforma = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _g2 = _rb.velocity.y;

        _anim.SetFloat("InputX", _animacao);

        if (_ativadorMovimento)
        {
            Movimento();
            
        }

        else
        {
    
            _rb.velocity = new Vector3(0, _rb.velocity.y, _rb.velocity.z);
        }

        
        Gravidade();


        if (_move.x > 0 && _rotacao)
        {
            Flip();
        }

        else if (_move.x < 0 && !_rotacao)
        {
            Flip();
        }

        //VidaGameOver
        if (_vida <= 0)
        {
            _ativadorMovimento = false;
            _anim.SetBool("Morte", true);
            _vida = 0;
        }

        if (_checkGround)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            Verificacao();
            coyoteTimeCounter -= Time.fixedDeltaTime;
        }


        ChecaDirecaoDoTiro();

    }


    void Verificacao()
    {

        if (Physics.Raycast(_raycasGround.position, transform.TransformDirection(Vector3.up), out teto, 10f))
        {
            Debug.DrawRay(_raycasGround.position, teto.point - transform.position, Color.red);

            if (teto.transform.CompareTag("Ground"))
            {
                _OnEnter.Invoke();
                _dentroPlataforma = true;
            }
            
        }
        else
        {

            _OnExit.Invoke();
            _dentroPlataforma = false;
        }



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

        if (value.performed && (_checkGround || _plataforma || coyoteTimeCounter > 0) && !_dentroPlataforma && _ativadorMovimento) //Jotapê
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _jump, _rb.velocity.z);
            coyoteTimeCounter = 0;
        }

    }

    public void SetAtaque(InputAction.CallbackContext value) //Jotapê
    {
        //Se estiver no chão, rola a animação dele atirando no chão
        if(value.performed && _checkGround && _ativadorMovimento && _ativaTiro)
        {
            
            StartCoroutine(TimeTiro());
        }

        //Se estiver no chão, rola a animação dele atirando no chão
        if (value.performed && !_checkGround && _ativadorMovimento && _ativaTiro)
        {
            StartCoroutine(TimeTiro());
        }


    }

    IEnumerator TimeTiro() //Jotapê
    {
        _anim.SetBool("Ataque", true);
        _ativaTiro = false;
        yield return new WaitForSeconds(.3f);
        TiroDoPlayer();
        _anim.SetBool("Ataque", false);
        _ativaTiro = true;
    }

    void ChecaDirecaoDoTiro()
    {
        if(_move.x > 0.1f)
        {
            _direcaoVerdadeira = true;
        }
        
        if(_move.x < -0.1f)
        {
            _direcaoVerdadeira = false;
        }


    } //Aqui que faz checar a dire

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




    public void VidaPlayer()
    {

        StartCoroutine(VidaTime());
    }

    IEnumerator VidaTime()
    {
        if(_dano == true)
        {
            _vida -= 1;
            for (int i = 0; i < 3; i++)
            {
                _PlayerHit.SetActive(false);
                yield return new WaitForSeconds(.1f);
                _PlayerHit.SetActive(true);
                yield return new WaitForSeconds(.5f);
                _dano = false;
            }
            _dano = true;
        }

    }

    private void OnTriggerEnter(Collider other)  //Jotapê
    {
        if (other.gameObject.CompareTag("Ground"))
        {

            
            _groundCount++;
            _checkGround = true;
            //Jotapê
            _anim.SetBool("Jump", false);
        }
        if (other.gameObject.CompareTag("Plataforma"))
        {
            _groundCount++;
            _plataforma = true;
            transform.SetParent(other.transform);// traformando o Player em parente da plataforma (Ivo)
            _checkGround = true;
            //Jotapê
            _anim.SetBool("Jump", false);

        }
    }

    private void OnTriggerExit(Collider other)  //Jotapê
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _groundCount--;
            if(_groundCount == 0)
            {
                _checkGround = false;
                //Jotapê
                _anim.SetBool("Jump", true);
            }
            
        }
        if (other.gameObject.CompareTag("Plataforma"))
        {
            _groundCount--;
            if(_groundCount == 0)
            {
                _plataforma = false;
                transform.SetParent(_PosPlayer.transform); //movimento de plataforma (Ivo)
                _checkGround = false;
                //Jotapê
                _anim.SetBool("Jump", true);
            }

        }
    }

    private void TiroDoPlayer()
    {
        
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = _posTiro.transform.position;
            bullet.SetActive(true);

            //Verifica a Direção do Tiro
            if (_direcaoVerdadeira == true)
            {
                bullet.gameObject.GetComponent<Tiro>().direction = 1;
            }

            else if(_direcaoVerdadeira == false)
            {
                bullet.gameObject.GetComponent<Tiro>().direction = -1;
            }

        }
    }

}
