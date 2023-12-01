using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoMove : MonoBehaviour
{
    NavMeshAgent _agent;
    [SerializeField] Transform _alvo;
    [SerializeField] Transform _player;
    [SerializeField] Transform[] _pos;

    int _numberM;

    float _distancia;
    float _distanciaPlayer;
    [SerializeField] float _distanciaPatrulhar;

    bool _seguirPlayer;

    Vector3 _speedAgent;
    [SerializeField] float _speedAnim;

    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        _speedAgent = _agent.velocity;
        Movimento();
        Animacao();
    }
    void Patrulhar()
    {
        if (_distancia < _distanciaPatrulhar && _numberM == 0)
        {
            _numberM = 1;
        }
        else if (_distancia < _distanciaPatrulhar && _numberM == 1)
        {
            _numberM = 0;
        }
        _alvo = _pos[_numberM];
    }
    void Animacao()
    {
        _speedAnim = MathF.Abs(_speedAgent.x + _speedAgent.z);
        _animator.SetFloat("Speed", _speedAnim);
    }

    void Movimento()
    {
        _distancia = _agent.remainingDistance;
        _distanciaPlayer = Vector3.Distance(transform.position, _player.position);
        if (_distanciaPlayer < 8)
        {
            _seguirPlayer = true;
        }
        else
        {
            _seguirPlayer = false;
        }

        if (!_seguirPlayer)
        {
            Patrulhar();
            _agent.SetDestination(_alvo.position);
        }
        else
        {
            _agent.SetDestination(_player.position);
        }
    }

}

