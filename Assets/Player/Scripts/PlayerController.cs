using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] DynamicJoystick _dynamicJoystick;

    [SerializeField] Transform _verificaParede;
    [SerializeField] bool ativaJump;

    //Variaveis Publicas
    CameraShake _shakeCam;
    Chicote _chicote;
    public GameManager _pausaJogo;
    GameControle _gameControle;

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


    public bool _rotacao;
    int _runHash = Animator.StringToHash("Andando");
    int _jumpHash = Animator.StringToHash("Jump");
    int _rumJump = Animator.StringToHash("RunJump");
    [SerializeField] bool _plataforma;

    //Posicao do Tiro
    public Transform _posTiro;
    private bool _direcaoVerdadeira;
    public bool _ativaTiro;

    [Header("Sistema de Orientacao de Objeto")]
    [SerializeField] UnityEvent _OnEnter;
    [SerializeField] UnityEvent _OnExit;
    [SerializeField] private bool _dentroPlataforma;

    [SerializeField] private GameObject transicaoGameOver;
    [SerializeField] private GameObject painelGameOver;
    public AudioSource _SomDoPulo;

    [SerializeField] string _tagCheckPoint;
    CheckPoint _checkpoint;
    public Vector3 _posSalva;

    [Header("Variaveis para Suavizar a Animacao")]
    [SerializeField] private float smoothInputX;
    [SerializeField] private float velocityX;



    // Start is called before the first frame update
    void Start()
    {
        _shakeCam = FindAnyObjectByType<CameraShake>();
        _chicote = FindAnyObjectByType<Chicote>();
        _pausaJogo = FindAnyObjectByType<GameManager>();

        _gameControle = Camera.main.GetComponent<GameControle>();



        //painelGameOver.SetActive(false);
        _ativaTiro = true;
        _direcaoVerdadeira = true;
        _ativadorMovimento = true;
        _dentroPlataforma = false;

        _checkpoint = Camera.main.GetComponent<CheckPoint>();
        if (PlayerPrefs.GetInt("StartSalve") == 1)
        {
            _posSalva.x = PlayerPrefs.GetFloat("posX");
            _posSalva.y = PlayerPrefs.GetFloat("posY");
            _posSalva.z = PlayerPrefs.GetFloat("posZ");
            //transform.localPosition = _posSalva;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (_pausaJogo._pause == false)
        {
            AnimacaoPlayer();
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

            TransformacaoTransicao();


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
            if(_checkPedra.transform.CompareTag("Pedra"))
            {
                GetComponent<CapsuleCollider>().center = new Vector3(0, 4, 2);
                _anim.SetLayerWeight(3, 1);
                _anim.SetBool("Empurrar", true);
            }
        }
        else
        {
            GetComponent<CapsuleCollider>().center = new Vector3(0, 4, 0);
            _anim.SetLayerWeight(0, 1);
            _anim.SetBool("Empurrar", false);
        }

    }



    public void SetMove(InputAction.CallbackContext value) //Jotap�
    {

        _move = value.ReadValue<Vector3>().normalized;
        _dynamicJoystick._verificaJoystick = false;

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
        if(_dynamicJoystick._verificaJoystick == true) //Usa Joystick Celular
        {
            _move.x = _dynamicJoystick.Horizontal;
            _rb.velocity = new Vector3(_move.x * _speed, _rb.velocity.y, _rb.velocity.z);
        }
        else if(_dynamicJoystick._verificaJoystick == false)
        {
            _rb.velocity = new Vector3(_move.x * _speed, _rb.velocity.y, _rb.velocity.z);
        }
    }

    public void SetJump(InputAction.CallbackContext value)
    {

        if (value.performed && !ativaJump) //Jotap�
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
        if(_bauOn == true && _gameControle._cadeadoMT._bauAberto == false)
        {
            _gameControle._cadeadoMT._bauAberto = true;
            _gameControle._cadeadoMT._puzzleHud.SetActive(true);
            _gameControle._cadeadoMT.ChamaQuestao(_gameControle._cadeadoMT._question);
            _gameControle._cadeadoMT._question++;
            _pausaJogo._pause = true;


            _gameControle._eventButton.firstSelectedGameObject = _gameControle._btPuzzles[0]; //Faz o botão Cima do Puzzle ser o Primeiro do EventSystem
            _gameControle._btPuzzles[0].GetComponent<Button>().Select();
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
            GameOver();
            
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
            _shakeCam.Shake();
            _ativaDefesa = true;
            _hudDefesaUp.SetActive(true);
            _defesaUp = 3;
            _vida = 3;
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
        if (other.gameObject.CompareTag(_tagCheckPoint))
        {
            //Debug.Log(other.transform.localPosition); //mostra o local do objrto(checkpoint)
            UnityEngine.Debug.Log(other.gameObject.name); //mostra o nome do objeto(checkpoint)
            _checkpoint.Salvar();
            _checkpoint.CkeckPointSalvar(other.transform.localPosition);
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
    private void GameOver()
    {
        //transicaoGameOver.transform.position = transform.position;
       // transicaoGameOver.SetActive(true);
        _ativadorMovimento = false;
        StartCoroutine(ExibirPainelGameOver());
        

    }
   

    private IEnumerator ExibirPainelGameOver()
    {
        yield return new WaitForSeconds(2f);
        painelGameOver.SetActive(true);
        _TelaGameOver.DOScale(.8f, 1f);
        yield return new WaitForSeconds(1f);
        DOTween.KillAll();
    }

    private IEnumerator Transforme()
    {
        _paticula.SetActive(true);
        yield return new WaitForSeconds(1f);
        _paticula.SetActive(false);
    }

}
