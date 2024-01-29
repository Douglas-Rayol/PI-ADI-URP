using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cogula : MonoBehaviour
{
    Rigidbody _rb;
    Animator _anim;
    bool _isFacingRight;
    bool _ataqueOn;
    float _distPlayer;
    bool _hit;
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

    public int _vidaAtual;
    public int _vidbMax;
    public Transform _barCheio; //barra verde
    public GameObject _barraVida; //barra principal(pai)

    private Vector3 _barScale; //tamanho da barra
    private float _barPercent; //calcula o percentual da vida do tamanho da barra 
    bool _stop;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _barScale = _barCheio.localScale;
        _barPercent = _barScale.x / _vidaAtual;
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
        if (Input.GetKeyDown(KeyCode.LeftControl) && _vidaAtual >= 1)
        {
            AplicarDano();
        }
        Anim();
        BarraDevida();
        
    }

    void Anim()
    {
        _anim.SetFloat("Andando", Mathf.Abs(_rb.velocity.x));
        //_anim.SetBool("isPlayer", _isPlayer);
        _anim.SetBool("Hit", _hit);
        _anim.SetBool("Attack", _ataqueOn);
    }

    void Ataque()
    {
        _rb.velocity = new Vector3(0, _rb.velocity.y);
    }
    void AplicarDano()
    {
        _barraVida.SetActive(true);
        _vidaAtual -= 1;
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
        _stop = false;
    }

    void BarraDevida()
    {
        _barScale.x = _barPercent * _vidaAtual;
        _barCheio.localScale = _barScale;
    }


    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 theScale = transform.localEulerAngles;
        theScale.y *= -1;
        transform.localEulerAngles = theScale;
        _barraVida.transform.localScale = new Vector3(_barraVida.transform.localScale.x, _barraVida.transform.localScale.y, _barraVida.transform.localScale.z * -1);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(TempoDeAtaque());
            
        }
        if (collision.gameObject.CompareTag("AtaquePlayer"))
        {
            _hit = true;
            _stop = true;
        }
    }
    
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("AtaquePlayer"))
        {
            _hit = false;
            Invoke("StopOff", 0.8f);
        }
    }

    IEnumerator TempoDeAtaque()
    {
        _ataqueOn = true;
        yield return new WaitForSeconds(.5f);
        _ataqueOn = false;
    }
}
