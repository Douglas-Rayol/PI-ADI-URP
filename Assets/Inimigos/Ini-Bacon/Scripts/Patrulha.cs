using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Patrulha : MonoBehaviour
{

    Rigidbody _rb;
    Animator _anim;
    bool _isFacingRight;
    bool _isPlayer;
    private bool _hit;
    float _distPlayer;
    [SerializeField] Transform _player;
    [SerializeField] Transform _alvo;
    [SerializeField] Transform[] _pos;
    [SerializeField] float[] _distPos;
    [SerializeField] float[] _velocidade;
    [SerializeField] float _distPosLimit;
    [SerializeField] float _distPlayerLimit;
    [SerializeField] float _moveVelocidade;
    [SerializeField] GameObject _paticula;
    [SerializeField]GameObject _bacon, _porco;

    [Header("Sistema de vida Cogula")]
    [SerializeField] public int _vida;
    //Barra de vida Bacon
    public Transform _barCheio; //barra verde
    public GameObject _barraVida; //barra principal(pai)
    private Vector3 _barScale; //tamanho da barra
    private float _barPercent; //calcula o percentual da vida do tamanho da barra
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        // barra de vida bacon
        _barScale = _barCheio.localScale;
        _barPercent = _barScale.x / _vida;
        _barraVida.SetActive(false);
    }

    void Update()
    {
        _distPos[0] = Vector3.Distance(transform.position, _pos[0].position);
        _distPos[1] = Vector3.Distance(transform.position, _pos[1].position);
        Patrulhamento();
        MoverparaAlvo();
        BarraDevida();
    }

    void Patrulhamento()
    {
        if (_distPos[0] < _distPlayerLimit && _isPlayer == false)
        {
            _alvo = _pos[1];
        }
        if (_distPos[1] < _distPlayerLimit && _isPlayer == false)
        {
            _alvo = _pos[0];
        }
    }

    void MoverparaAlvo()
    {
        if (transform.position.x < _alvo.position.x)
        {
            _rb.velocity = new Vector3(_moveVelocidade, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector3(-_moveVelocidade, _rb.velocity.y);
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

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 theScale = transform.localEulerAngles;
        theScale.y *= -1;
        transform.localEulerAngles = theScale;
        _barraVida.transform.localScale = new Vector3(_barraVida.transform.localScale.x, _barraVida.transform.localScale.y, _barraVida.transform.localScale.z * -1);
    }
    void BarraDevida()
    {
        _barScale.x = _barPercent * _vida;
        _barCheio.localScale = _barScale;
        
        if(_vida <= 0)
        {
            _vida = 0;
            _barraVida.SetActive(false);
        }
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("AtaquePlayer"))
        {
            AplicarDano();
            _hit = true;
        }
    }
    IEnumerator Morte()
    {
        _paticula.SetActive(true);
        yield return new WaitForSeconds(.2f);
        _bacon.gameObject.SetActive(false);
        _porco.gameObject.SetActive(true);
    }
}
