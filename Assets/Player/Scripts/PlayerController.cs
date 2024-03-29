using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    //Variaveis Publicas
    [SerializeField] Chicote _chicote;
    public GameManager _pausaJogo;
    Bau _podeAbrir;

    [SerializeField] int coyote;
    [SerializeField] bool SinalCoyote;
    [SerializeField] float timeCoyote;

    //Vida do Jogador
    [SerializeField] public int _vida = 3;
    [SerializeField] bool _dano;
    [SerializeField] GameObject[] _PlayerHitPadrao;
    [SerializeField] GameObject[] _PlayerHitInd;
    [SerializeField] GameObject[] _PlayerHitMago;
    [SerializeField] GameObject _paticula;

    GameObject bullet;

    [SerializeField] int _trocaS = 0;

    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _anim;
    [SerializeField] public Vector2 _move;
    [SerializeField] Transform _raycasGround;

    [SerializeField] float _speed;
    [SerializeField] float _jump;
    [SerializeField] float _gravidade;
    [SerializeField] private float coyoteTime = 0f;
    [SerializeField] Transform _TelaGameOver;

    public bool _ativadorMovimento;

    RaycastHit teto;

    [SerializeField] Transform _PosPlayer;
    [SerializeField] float _g2;
    [SerializeField] bool _checkGround;
    [SerializeField] int _groundCount;
    bool checkHitIni;


    bool _rotacao;
    private float _animacao;
    int _runHash = Animator.StringToHash("Andando");
    int _jumpHash = Animator.StringToHash("Jump");
    int _rumJump = Animator.StringToHash("RunJump");
    [SerializeField] bool _plataforma;

    //Posic�o do Tiro
    public Transform _posTiro;
    private bool _direcaoVerdadeira;
    public bool _ativaTiro;

    [Header("Sistema de Orienta��o de Objeto")]
    [SerializeField] UnityEvent _OnEnter;
    [SerializeField] UnityEvent _OnExit;
    [SerializeField] private bool _dentroPlataforma;

    [SerializeField] private GameObject transicaoGameOver;
    [SerializeField] private GameObject painelGameOver;
    public AudioSource _SomDoPulo;


    
    


    // Start is called before the first frame update
    void Start()
    {
        _chicote = FindAnyObjectByType<Chicote>();
        _pausaJogo = FindAnyObjectByType<GameManager>();
        _podeAbrir = FindAnyObjectByType<Bau>();

        _ativaTiro = true;
        _direcaoVerdadeira = true;
        _ativadorMovimento = true;
        _dentroPlataforma = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if(_pausaJogo._pause == false)
        {
            _anim.SetLayerWeight(0, 1);
            _anim.SetBool("Transform", false);
            

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
                // GameOver();
            }

            if (!_checkGround)
            {
                Verificacao();
            }

            if (SinalCoyote == true)
            {
                if (!_checkGround)
                {
                    coyote = 0;
                    SinalCoyote = false;
                }
            }

            if (coyote == 1)
            {
                timeCoyote += Time.deltaTime;
                if (timeCoyote > .15f)
                {
                    coyote = 0;

                }

            }


            ChecaDirecaoDoTiro();
        }
        else
        {
            _rb.velocity = Vector3.zero;
            TransformacaoTransicao();
            


        }


    }


    void TransformacaoTransicao()
    {
        
        _anim.SetLayerWeight(1, 1);
        _anim.SetBool("Transform", true);
        StartCoroutine(Transforme());
    }

    void Verificacao()
    {

        if (Physics.Raycast(_raycasGround.position, transform.TransformDirection(Vector3.up), out teto, 10f))
        {
            SinalCoyote = true;
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

    public void SetMove(InputAction.CallbackContext value) //Jotap�
    {

        _move = value.ReadValue<Vector3>().normalized;
        

    }

    void Movimento() //Jotap�
    {

        _rb.velocity = new Vector3(_move.x * _speed, _rb.velocity.y, _rb.velocity.z);
        _animacao = Mathf.Abs(_move.x);
    }

    public void SetJump(InputAction.CallbackContext value)
    {

        if (value.performed) //Jotap�
        {
            
            if ((_checkGround || _plataforma || coyote == 1) && !_dentroPlataforma && _ativadorMovimento)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, _jump, _rb.velocity.z);
                SinalCoyote = true;
                _SomDoPulo.Play();

            }
        }

         
    }

    public void SetAbrirBau(InputAction.CallbackContext value)
    {
        if(_podeAbrir._abrir == true)
        {
            _podeAbrir._anim.SetBool("Aberto", true);
            _podeAbrir._seta.SetActive(false);
            _podeAbrir._desativa = true;

        }
    }

    public void SetAtaque(InputAction.CallbackContext value) //Jotap�
    {
        if(_pausaJogo._pause == false)
        {
            //Se estiver no ch�o, rola a anima��o dele atirando no ch�o
            if (value.performed && _checkGround && _ativadorMovimento && _ativaTiro)
            {

                StartCoroutine(TimeTiro());

            }

            //Se estiver no ch�o, rola a anima��o dele atirando no ch�o
            if (value.performed && !_checkGround && _ativadorMovimento && _ativaTiro)
            {

                StartCoroutine(TimeTiro());

            }
        }


    }

    public void AtaqueChicote()
    {
        _chicote.ChicoteLigado();
    }

    public void AtivaTiro()
    {
        TiroDoPlayer();
    }

    IEnumerator TimeTiro() //Jotap�
    {
        
        if(_trocaS == 0 || _trocaS == 2)
        {
            _anim.SetBool("Ataque", true);
            _ativaTiro = false;
            _ativadorMovimento = false;
            yield return new WaitForSeconds(.3f);
            _anim.SetBool("Ataque", false);
            yield return new WaitForSeconds(.32f);
            _ativadorMovimento = true;
            _ativaTiro = true;
        }

        if(_trocaS == 1)
        {
            _anim.SetBool("AtaqueIndi", true);
            _ativaTiro = false;
            _ativadorMovimento = false;
            yield return new WaitForSeconds(.3f);
            _anim.SetBool("AtaqueIndi", false);
            yield return new WaitForSeconds(.32f);
            _ativadorMovimento = true;
            _ativaTiro = true;
        }
       
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

    void Gravidade()  //Jotap�
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

      if ( _vida <= 0)
      {
            GameOver();
      }

    }

    IEnumerator VidaTime()
    {
        _vida -= 1;

        for (int i = 0; i < 30; i++)
        {
            if(_trocaS == 0)
            {
                _PlayerHitPadrao[0].SetActive(false);
            }

            if(_trocaS == 1)
            {
                _PlayerHitInd[0].SetActive(false);
                _PlayerHitInd[1].SetActive(false);
            }

            if (_trocaS == 2)
            {
                _PlayerHitMago[0].SetActive(false);
                _PlayerHitMago[1].SetActive(false);
            }

            yield return new WaitForSeconds(.010f);

            if (_trocaS == 0)
            {
                _PlayerHitPadrao[0].SetActive(true);
            }

            if (_trocaS == 1)
            {
                _PlayerHitInd[0].SetActive(true);
                _PlayerHitInd[1].SetActive(true);
            }

            if (_trocaS == 2)
            {
                _PlayerHitMago[0].SetActive(true);
                _PlayerHitMago[1].SetActive(true);
            }

            yield return new WaitForSeconds(.02f);
            
        }
        _dano = false;


    }

    private void OnTriggerEnter(Collider other)  //Jotap�
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if(SinalCoyote == false)
            {
                coyote = 0;
                timeCoyote = 0f;
            }
            _groundCount++;
            _checkGround = true;
            //Jotap�
            _anim.SetBool("Jump", false);
        }
        if (other.gameObject.CompareTag("Plataforma"))
        {
            if(SinalCoyote == false)
            {
                coyote = 0;
                timeCoyote = 0f;
            }
            _groundCount++;
            _plataforma = true;
            transform.SetParent(other.transform);// traformando o Player em parente da plataforma (Ivo)
            _checkGround = true;
            //Jotap�
            _anim.SetBool("Jump", false);
        }

        if (other.gameObject.CompareTag("Chapeu"))
        {
            
            other.GetComponent<Item>().DestroyItem();
            _pausaJogo._pause = true;
            _PlayerHitPadrao[0].SetActive(false);
            _PlayerHitInd[0].SetActive(true);
            _PlayerHitInd[1].SetActive(true);
            _PlayerHitInd[2].SetActive(true);
            _PlayerHitMago[0].SetActive(false);
            _PlayerHitMago[1].SetActive(false);
            _PlayerHitMago[2].SetActive(false);
            _trocaS = 1;
            

        }

        if (other.gameObject.CompareTag("Cajado"))
        {
            other.GetComponent<Item>().DestroyItem();
            _pausaJogo._pause = true;
            _PlayerHitPadrao[0].SetActive(false);
            _PlayerHitInd[0].SetActive(false);
            _PlayerHitInd[1].SetActive(false);
            _PlayerHitInd[2].SetActive(false);
            _PlayerHitMago[0].SetActive(true);
            _PlayerHitMago[1].SetActive(true);
            _PlayerHitMago[2].SetActive(true);
            _trocaS = 2;


        }


        if (other.gameObject.CompareTag("AtaqueEnemy") && _dano == false)
        {
           _dano = true;
           VidaPlayer();
        }
        if (other.gameObject.CompareTag("Morte"))
        {
            GameOver();
        }
    }


    private void OnTriggerExit(Collider other)  //Jotap�
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            coyote = 1;
            _groundCount--;
            if(_groundCount == 0)
            {
                _checkGround = false;
                //Jotap�
                _anim.SetBool("Jump", true);
            }
            
        }
        if (other.gameObject.CompareTag("Plataforma"))
        {
            
            coyote = 1;
            _groundCount--;
            if (_groundCount == 0)
            {
                _plataforma = false;
                transform.SetParent(_PosPlayer.transform); //movimento de plataforma (Ivo)
                _checkGround = false;
                //Jotap�
                _anim.SetBool("Jump", true);
            }

        }
    }

    private void TiroDoPlayer()
    {

        bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = _posTiro.transform.position;
            bullet.SetActive(true);

            //Verifica a Dire��o do Tiro
            if (_direcaoVerdadeira == true)
            {
                bullet.gameObject.GetComponent<Tiro>().direction = 1;

            }

            else if (_direcaoVerdadeira == false)
            {
                bullet.gameObject.GetComponent<Tiro>().direction = -1;
            }

        }



    }
    private void GameOver()
    {
        //transicaoGameOver.transform.position = transform.position;
       // transicaoGameOver.SetActive(true);
        _ativadorMovimento = false;
        StartCoroutine(ExibirPainelGameOver());
        _TelaGameOver.DOScale(1, 0.8f);
        
    }
   

    private IEnumerator ExibirPainelGameOver()
    {
        yield return new WaitForSecondsRealtime(1f);
        painelGameOver.SetActive(true);
        DOTween.KillAll();
    }

    IEnumerator Transforme()
    {
        _paticula.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        _paticula.SetActive(false);
    }
}
