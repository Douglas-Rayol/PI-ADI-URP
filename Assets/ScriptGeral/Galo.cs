using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Galo : MonoBehaviour
{
    [SerializeField] GameControle _gameControle;
    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _anim;
    [SerializeField] float _speed;
    [SerializeField] float _speedMin;
    [SerializeField] float _speedMax;
    [SerializeField] int _direction;
    [SerializeField] float _gravidade;
    [SerializeField] bool _checkGround;
    [SerializeField] float _galoH;
    [SerializeField] int _aleatorio;
    [SerializeField] int _index;

    //HP do Boss
    [SerializeField] int _vidaMin;
    [SerializeField] int _vidaMax;
    [SerializeField] Image _imgHpBoss;


    void Awake()
    {
        _gameControle = Camera.main.GetComponent<GameControle>();

        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

        InvokeRepeating(nameof(AtaquesAleatorios), 0f, 2f); //Invoka aleatoriamente os ataques do boss
    }

    private void AtaquesAleatorios()
    {
        _aleatorio = Random.Range(0, 3);
    }

    void FixedUpdate()
    {
        if(!_gameControle.GetComponent<GameManager>()._pause)
        {
            float _distance = Vector3.Distance(transform.position, _gameControle._playerController.transform.position);
            _galoH = _gameControle._playerController.transform.position.x - transform.position.x;

            _imgHpBoss.fillAmount = (float)_vidaMin / _vidaMax;

            if(_distance < 10f && _aleatorio == 1)
            {
                if(_checkGround)
                {
                    _anim.SetTrigger("Ataque");
                    _anim.SetBool("Andar", false);
                    _anim.SetLayerWeight(0, 1);
                    _rb.velocity = Vector3.zero;
                }
            }
            else if(_distance > 10f && _aleatorio == 2) //Se ele tiver a 30 de distancia (Ativa Soco Dash)
            {
                if(_checkGround)
                {
                    _anim.SetTrigger("SuperAtaque");
                    _anim.SetBool("Andar", false);
                    _anim.SetLayerWeight(0, 1);

                }
            }
            else
            {
                if(_checkGround && _aleatorio == 0)
                {
                    _anim.SetBool("Andar", true);
                    _anim.SetLayerWeight(1, 1);

                }
            }

            FlipDoGalo();
            GravidaGalo();


            if(_vidaMin <= 0)
            {
                _gameControle.GetComponent<CenaFinalBoss>().Invoke("CenaFinal", 3f);
                gameObject.SetActive(false);
                _vidaMin = 0;
                
            }
        }

        

    }

    private void FlipDoGalo()
    {
        if (_galoH >= 5f)
        {
            _direction = 1;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -3);
        }
        
        if (_galoH <= -5f)
        {
            _direction = -1;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 3);
        }
    }

    private void GravidaGalo()
    {
        _rb.AddForce(Vector3.down * _gravidade);
    }


    public void Andando()
    {
        if(_checkGround && !_gameControle.GetComponent<GameManager>()._pause)
        {
            _speed = Random.Range(_speedMin, _speedMax);
            _rb.velocity = new Vector3(_direction * _speed, _rb.velocity.y, _rb.velocity.z);
        }
    }


    public void SuperAtaque()
    {
        if (_checkGround && !_gameControle.GetComponent<GameManager>()._pause)
        {
            _rb.velocity = new Vector3(_direction * _speed * 10, 0, 0);
        }
    }

    public void Paradinha() 
    {
        _rb.velocity = Vector3.zero;
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            _checkGround = true;

            _index++;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AtaquePlayer"))
        {
            if(_gameControle._playerController._trocaS == 0)
            {
                _vidaMin -= 1;
            }
            else
            {
                _vidaMin -= 2;
            }
            
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            _index--;

            if(_index <= 0)
            {
                _checkGround = false;
            }
            
        }
    }

}
