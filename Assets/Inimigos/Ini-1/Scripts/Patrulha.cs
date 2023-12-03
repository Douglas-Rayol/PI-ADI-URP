using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulha : MonoBehaviour
{
    Rigidbody _rb;
    Animator _anim;
    bool _isFacingRight;
    float _distPlayer;
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
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //_distPlayer = Vector3.Distance(transform.position, _player.position);
        _distPos[0] = Vector3.Distance(transform.position, _pos[0].position);
        _distPos[1] = Vector3.Distance(transform.position, _pos[1].position);
        Patrulhamento();
        MoverparaAlvo();
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
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
