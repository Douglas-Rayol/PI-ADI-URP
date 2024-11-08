using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    [Header("Componentes Globais")]
    [SerializeField] Gerenciadordepartida _gerenciadorControle;

    [SerializeField] Transform _verificaParede;

    Chicote _chicote;
    GameManager _gameManager;
    GameControle _gameControle;

    //Variaveis PosInicial
    [SerializeField] public Vector3 _posInicial;

    [SerializeField] bool ativaJump;

    [SerializeField] int coyote;
    [SerializeField] float timeCoyote;

    //Vida do Jogador
    [SerializeField] public int _vida = 3;
    [SerializeField] public int _defesaUp = 0;
    [SerializeField] bool _dano;
    [SerializeField] bool SinalCoyote;
    [SerializeField] public bool _bauOn;
    [SerializeField] public bool _ativaDefesa;
    
    [SerializeField] GameObject[] _PlayerHitPadrao;
    [SerializeField] GameObject[] _PlayerHitInd;
    [SerializeField] GameObject[] _PlayerHitMago;
    [SerializeField] GameObject _paticula;
    [SerializeField] GameObject _hudDefesaUp;

    GameObject cura;

    [SerializeField] public int _trocaS = 0;

    [SerializeField] public Rigidbody _rb;
    [SerializeField] Animator _anim;
    [SerializeField] public Vector2 _move;
    [SerializeField] private float _ultimaHorizontal;
    [SerializeField] Transform _raycasGround;

    [SerializeField] float _speed;
    [SerializeField] public float _jump;
    [SerializeField] public float _gravidade;
    [SerializeField] public float coyoteTime = 0f;

    public bool _ativadorMovimento;

    RaycastHit teto;

    [SerializeField] Transform _PosPlayer;
    [SerializeField] float _g2;
    [SerializeField] public bool _checkGround;
    [SerializeField] public int _groundCount;

    bool checkHitIni;
    public bool _rotacao;

    [SerializeField] public bool _plataforma;

    //Posicao do Tiro
    public Transform _posTiro;
    private bool _direcaoVerdadeira;
    public bool _ativaTiro;

    [Header("Sistema de Orientacao de Objeto")]
    [SerializeField] UnityEvent _OnEnter;
    [SerializeField] UnityEvent _OnExit;
    [SerializeField] private bool _dentroPlataforma;

    [SerializeField] private GameObject transicaoGameOver;
    public AudioSource _SomDoPulo;

    [Header("Variaveis para Suavizar a Animacao")]
    [SerializeField] private float smoothInputX;
    [SerializeField] private float velocityX;

    

    void Awake()
    {
        _gameManager = Camera.main.GetComponent<GameManager>();
        _gameControle = Camera.main.GetComponent<GameControle>();
        _gerenciadorControle = Camera.main.GetComponent<Gerenciadordepartida>();
    }


    // Start is called before the first frame update
    void Start()
    {
        _chicote = FindAnyObjectByType<Chicote>();

        _ativaTiro = true;
        _direcaoVerdadeira = true;
        _ativadorMovimento = true;
        _dentroPlataforma = false;

        if(PlayerPrefs.HasKey("posX") && PlayerPrefs.HasKey("posY") && PlayerPrefs.HasKey("posZ"))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), PlayerPrefs.GetFloat("posZ"));
        }
        else
        {
            _posInicial = transform.position;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AnimacaoPlayer();

        if (_gameManager._pause == false)
        {
            
            _anim.SetLayerWeight(0, 1);
            _anim.SetBool("Transform", false);
            

            _g2 = _rb.velocity.y;



            _anim.SetFloat("InputX", smoothInputX);
            

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

            if(_defesaUp == 0)
            {
                _ativaDefesa = false;

                if(_trocaS == 2)
                {
                    _PlayerHitMago[0].SetActive(false);
                    _PlayerHitMago[1].SetActive(false);
                    _PlayerHitMago[2].SetActive(false);
                    _PlayerHitPadrao[0].SetActive(true);
                    _trocaS = 0;

                }

            }

            if (!_checkGround)
            {
                VerificaTeto();
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
            VerificaFrente();


        }
        else
        {
            _rb.velocity = Vector3.zero;
            _anim.SetFloat("InputX", 0);
            



        }


    }



    public void TransformacaoTransicao()
    {
        
        _anim.SetLayerWeight(1, 1);
        _anim.SetBool("Transform", true);
        StartCoroutine(Transforme());
    }



    void AnimacaoPlayer()
    {
        smoothInputX = Mathf.SmoothDamp(smoothInputX, _move.x, ref velocityX, 0.1f);

    }

    void VerificaTeto()
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

    void VerificaFrente()
    {
        RaycastHit _checkPedra;

        if(Physics.Raycast(_verificaParede.position, transform.TransformDirection(Vector3.forward), out _checkPedra, 2f))
        {   
            if(_checkPedra.transform.CompareTag("Pedra") && _move.x != 0)
            {
                GetComponent<CapsuleCollider>().center = new Vector3(0, 4, 2);
                _anim.SetLayerWeight(3, 1);
                _anim.SetBool("Empurrar", true);
                _ativaTiro = false;
            }
            else
            {
                _anim.SetBool("Empurrar", false);
            }
        }
        else
        {
            GetComponent<CapsuleCollider>().center = new Vector3(0, 4, 0);
            _anim.SetLayerWeight(0, 1);
            _anim.SetBool("Empurrar", false);
            _ativaTiro = true;
        }

    }



    public void SetMove(InputAction.CallbackContext value) //Jotap�
    {

        _move = value.ReadValue<Vector3>().normalized;
        _gameControle._dynamicJoystick._verificaJoystick = false;

        if (_move.x > 0.1f)
        {
            _ultimaHorizontal = _move.x;
        }

        if(_move.x < -0.1f)
        {
            _ultimaHorizontal = _move.x;
        }
    }

    void Movimento() //Jotape
    {
        if(_gameControle._dynamicJoystick._verificaJoystick == true) //Usa Joystick Celular
        {
            _move.x = _gameControle._dynamicJoystick.Horizontal;
            _rb.velocity = new Vector3(_move.x * _speed, _rb.velocity.y, _rb.velocity.z);
        }
        else if(_gameControle._dynamicJoystick._verificaJoystick == false)
        {
            _rb.velocity = new Vector3(_move.x * _speed, _rb.velocity.y, _rb.velocity.z);
        }
    }

    public void SetJump(InputAction.CallbackContext value)
    {

        if (value.performed && !ativaJump && !_gameManager._pause) //Jotap�
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
        if(value.performed && _bauOn == true && _gameControle._cadeadoMT._bauAberto == false)
        {
            if(!PlayerPrefs.HasKey("ativaTutorial"))
            {
                PlayerPrefs.SetInt("ativaTutorial", 0);
            }

            if (PlayerPrefs.GetInt("ativaTutorial") == 0)
            {
                _gameControle._tutorialBau[0].SetActive(true);
                _gameControle._tutorialBau[1].GetComponent<Button>().Select();
                _gameControle.GetComponent<GameManager>()._pause = true;
                _bauOn = false;

                PlayerPrefs.SetInt("ativaTutorial", 1);
            }

            else if (PlayerPrefs.GetInt("ativaTutorial") == 1)
            {
                _gameControle.GetComponent<GameManager>()._pause = true;
                _gameControle.AtivaBau();
                _gameManager._pause = true;
            }





        }


    }

    public void SetAtaque(InputAction.CallbackContext value) //Jotap�
    {
        if(_gameManager._pause == false)
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
    
    public void SetStart(InputAction.CallbackContext value)
    {
        if(value.performed && !_gameControle._desativaStart)
        {
            if(!_gerenciadorControle._startMenu)
            {
                _gerenciadorControle.StartCoroutine("AtivaStartMenu");
                _gerenciadorControle._startMenu = true;
            }
            else
            {
                _gerenciadorControle.StartCoroutine("DesativaStartMenu");
                _gerenciadorControle._startMenu = false;
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

        _anim.SetLayerWeight(2, 1);
        if(_trocaS == 0 || _trocaS == 2)
        {

            _anim.SetBool("Ataque", true);
            _ativaTiro = false;
            //_ativadorMovimento = false;
            yield return new WaitForSeconds(.3f);
            _anim.SetBool("Ataque", false);
            yield return new WaitForSeconds(.1f);
            //_ativadorMovimento = true;
            _ativaTiro = true;
            _anim.SetLayerWeight(0, 1);
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
            _anim.SetLayerWeight(0, 1);
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

    void Gravidade()  //Jotape
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

        if(_ativaDefesa == false)
        {
            _ativadorMovimento = false;
            StartCoroutine(VidaTime());
            Invoke("TimeHitAnim", .5f);
            Empurrao();


        }

        if(_ativaDefesa == true && _defesaUp > 0)
        {
            _ativadorMovimento = false;
            StartCoroutine(DefesaTime());
            Invoke("TimeHitAnim", .5f);
            Empurrao();
        }

        


        if ( _vida <= 0)
        {
            _gameControle.GameOver();
            
        }

    }


    private void Empurrao()
    {
        if(_rotacao == false)
        {
            _rb.DOMove(new Vector3(_rb.transform.position.x - 5f, _rb.transform.position.y + 3, _rb.transform.position.z), .3f, false);
        }

        if(_rotacao == true)
        {
            _rb.DOMove(new Vector3(_rb.transform.position.x + 5f, _rb.transform.position.y + 3, _rb.transform.position.z), .3f, false);
        }

    }


    private void TimeHitAnim()
    {
        _ativadorMovimento = true;
    }

    private IEnumerator DefesaTime()
    {
        _defesaUp -= 1;


        for (int i = 0; i < 30; i++)
        {
            if (_trocaS == 0)
            {
                _PlayerHitPadrao[0].SetActive(false);
            }

            if (_trocaS == 1)
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

    private IEnumerator VidaTime()
    {
        _vida -= 1;
        _anim.SetBool("Hit", true);

        for (int i = 0; i < 30; i++)
        {
            
            if (_trocaS == 0)
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
            _anim.SetBool("Hit", false);
            

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
            transform.SetParent(other.transform);
            _checkGround = true;
            //Jotap�
            _anim.SetBool("Jump", false);
        }

        if (other.gameObject.CompareTag("Chapeu"))
        {
            TransformacaoTransicao();
            other.GetComponent<Item>().DestroyItem();
            _gameManager._pause = true;
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
            TransformacaoTransicao();
            other.GetComponent<Item>().DestroyItem();
            _gameControle.GetComponent<CameraShake>().Shake();
            _ativaDefesa = true;
            _hudDefesaUp.SetActive(true);
            _defesaUp = 3;
            _vida = 3;
            _gameManager._pause = true;
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
            _gameControle.GameOver();
        }

        if(other.gameObject.CompareTag("CheckPoint"))
        {
            _gameControle._checkPoint.SalvaPos();
        }
    }


    private void OnTriggerExit(Collider other)  //Jotap�
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            coyote = 1;

            _groundCount--;

            if (_groundCount == 0)
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
                transform.SetParent(_PosPlayer.transform);
                _checkGround = false;
                //Jotap�
                _anim.SetBool("Jump", true);
            }

        }
    }

    private void TiroDoPlayer()
    {

        cura = ObjectPool.SharedInstance.GetPooledObject();
        if (cura != null)
        {
            cura.transform.position = _posTiro.transform.position;
            cura.SetActive(true);

            //Verifica a Dire��o do Tiro
            if (_direcaoVerdadeira == true)
            {
                cura.gameObject.GetComponent<Tiro>().direction = 1;

            }

            else if (_direcaoVerdadeira == false)
            {
                cura.gameObject.GetComponent<Tiro>().direction = -1;
            }

        }

    }
   
    private IEnumerator Transforme()
    {
        _paticula.SetActive(true);
        yield return new WaitForSeconds(1f);
        _paticula.SetActive(false);
    }

}
