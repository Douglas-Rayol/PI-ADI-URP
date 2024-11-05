using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.Rendering;
using UnityEngine;

public class Galo : MonoBehaviour
{
    [SerializeField] GameControle _gameControle;
    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _anim;
    [SerializeField] float _speed;
    [SerializeField] int _direction;
    [SerializeField] float _gravidade;
    [SerializeField] bool _checkGround;
    [SerializeField] float _galoH;


    void Awake()
    {
        _gameControle = Camera.main.GetComponent<GameControle>();

        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float _distance = Vector3.Distance(transform.position, _gameControle._playerController.transform.position);
        _galoH = _gameControle._playerController.transform.position.x - transform.position.x;

        if(_distance <= 10f)
        {
            if(_checkGround)
            {
                _anim.SetTrigger("Ataque");
                _anim.SetBool("Andar", false);
                _anim.SetLayerWeight(0, 1);
                _rb.velocity = Vector3.zero;
            }
        }
        else if(_distance <= 20f) //Se ele tiver a 20 de distancia (Ativa Soco Dash)
        {
            if(_checkGround)
            {
                _anim.SetTrigger("SuperAtaque");
                _anim.SetBool("Andar", false);
                _anim.SetLayerWeight(0, 1);
                _rb.velocity = Vector3.zero;

            }
        }
        else
        {
            if(_checkGround)
            {
                _anim.SetBool("Andar", true);
                _anim.SetLayerWeight(1, 1);

            }
        }

        FlipDoGalo();
        

    }

    private void FlipDoGalo() //Nunca mais mexa aqui
    {
        if (_galoH >= 5f)
        {
            _direction = 1;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -3);
        }
        else if (_galoH <= -5f)
        {
            _direction = -1;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 3);
        }
    }


    public void Andando()
    {

        if(_checkGround)
        {
            _rb.velocity = new Vector3(_direction * _speed, _rb.velocity.y, _rb.velocity.z);
        }
    }


    public void SuperAtaque()
    {
        if (_checkGround)
        {
            _rb.AddForce(new Vector3(_direction * _speed * 10, 0, 0), ForceMode.VelocityChange);
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
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;
        }
    }

}
