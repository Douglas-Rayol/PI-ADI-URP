using System.Collections;
using UnityEngine;

public class Cogula : MonoBehaviour
{

    [Header("Sistema de vida Cogula")]
    [SerializeField] public int _vida;
    //Barra de vida Cogula
    public Transform _barCheio; //barra verde
    public GameObject _barraVida; //barra principal(pai)
    private Vector3 _barScale; //tamanho da barra
    private float _barPercent; //calcula o percentual da vida do tamanho da barra


    [Header("Sistema de IA do Inimigo")]
    [SerializeField] Transform _player;
    [SerializeField] Transform _alvo;
    [SerializeField] Transform[] _pos;
    [SerializeField] float[] _distPos;
    [SerializeField] float[] _velocidade;
    [SerializeField] float _distPosLimit;
    [SerializeField] float _distPlayerLimit;
    [SerializeField] float _moveVelocidade;
    [SerializeField] bool _isPlayer;
    [SerializeField] bool _stopPlayer;
    [SerializeField] GameObject _paticula, _cogula, _cogulinha;
    
    
    bool _checkHit;
    Rigidbody _rb;
    Animator _anim;
    bool _isFacingRight;
    bool _ataqueOn;
    float _distPlayer;
    [SerializeField] bool _hit;
    bool _stop;

    VidaEvent vidaEvent;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        // barra de vida cogula
        _barScale = _barCheio.localScale;
        _barPercent = _barScale.x / _vida;
        _barraVida.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        _distPlayer = Vector3.Distance(transform.position, _player.position);
        _distPos[0] = Vector3.Distance(transform.position, _pos[0].position);
        _distPos[1] = Vector3.Distance(transform.position, _pos[1].position);
        if (_ataqueOn == false)
        {
            SeguirPlayer();
            Patrulhamento();
            MoverparaAlvo();
        }
        else
        {
           Ataque();
        }
        Anim();
        BarraDevida(); 

    }

    void Anim()
    {
        _anim.SetFloat("Andando", Mathf.Abs(_rb.velocity.x));
        //_anim.SetBool("isPlayer", _isPlayer);
        _anim.SetBool("Attack", _ataqueOn);

    }

    void Ataque()
    {
        _rb.velocity = new Vector3(0, _rb.velocity.y);
    }
    
    void Patrulhamento()
    {
        if (_distPos[0] < _distPlayerLimit && _isPlayer == false)
        {
            _alvo = _pos[1];
            _stopPlayer = true;
        }
        if (_distPos[1] < _distPlayerLimit && _isPlayer == false)
        {
            _alvo = _pos[0];
            _stopPlayer = true;
        }
    }

    void SeguirPlayer()
    {
        if (_distPlayer < _distPlayerLimit)
        {
            _isPlayer = true;
            _alvo = _player;
            _stopPlayer = false;
            _moveVelocidade = _velocidade[1];
        }
        else
        {
            _isPlayer = false;
            if (_stopPlayer == false)
            {
                _alvo = _pos[0];
                _moveVelocidade = _velocidade[0];
                _stopPlayer = true;
            }
        }
    }

    void MoverparaAlvo()
    {
        if (_hit == false && _stop == false)
        {
            if (transform.position.x < _alvo.position.x)
            {
                _rb.velocity = new Vector3(_moveVelocidade, _rb.velocity.y);
            }
            else
            {
                _rb.velocity = new Vector3(-_moveVelocidade, _rb.velocity.y);
            }
        }
        else
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y);

        }

        if (_rb.velocity.x < 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (_rb.velocity.x > 0 && _isFacingRight)
        {
            Flip();
        }
    }

    public void StopOff()
    {
        _stop = true;
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 theScale = transform.localEulerAngles;
        theScale.y *= -1;
        transform.localEulerAngles = theScale;
        _barraVida.transform.localScale = new Vector3(_barraVida.transform.localScale.x, _barraVida.transform.localScale.y, _barraVida.transform.localScale.z * -1);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AtaquePlayer") && _checkHit == false)
        {
            _checkHit = true;
            _anim.SetBool("Hit", true);
            Invoke("HitTime", .25f);
            _stop = true;
            AplicarDano();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            _ataqueOn = true;
            _stop = true;
            Invoke("StopTime", 1f);
        }

    }
    void HitTime()
    {
        _anim.SetBool("Hit", false);
        _stop = false;
        _checkHit = false;
    }
    


    void StopTime()
    {
        _stop = false;
        _ataqueOn = false;
    }

    public void AplicarDano()
    {
        _barraVida.SetActive(true);
        
        _vida -= 1;

      
        if (_vida <= 0)
        {
            StartCoroutine(Morte());
        }
    }

    void BarraDevida()
    {
        _barScale.x = _barPercent * _vida;
        _barCheio.localScale = _barScale;
    }

    IEnumerator Morte()
    {
        _paticula.gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        _cogula.gameObject.SetActive(false);
        _cogulinha.gameObject.SetActive(true);
        _barraVida.SetActive(false);
        _vida = 0;
    }
}
