using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMap : MonoBehaviour
{
    
    
    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _anim;
    [SerializeField] public NavMeshAgent _agentPlayer;
    [SerializeField] Vector3 _move;
    [SerializeField] MapControle _mapControle;
    
    [SerializeField] public int _mudaFase;
    [SerializeField] bool _checkPos;
    [SerializeField] public bool _podeAvanca;
    [SerializeField] int _numPag;

    

    void Start()
    {
        _mapControle = Camera.main.GetComponent<MapControle>();
    }

    // Update is called once per frame
    void Update()
    {
        _numPag = PlayerPrefs.GetInt("SalvaPaginaScore");
        AnimacaoPlayerMap();

        float _distance = Vector3.Distance(transform.position, _mapControle._posFase[_mudaFase].position);

        if (_mudaFase > 0)
        {
            _agentPlayer.SetDestination(_mapControle._posFase[_mudaFase].position);
            
        }


    }


    public void SetFrente(InputAction.CallbackContext value)
    {

        if (value.performed && !_checkPos && _podeAvanca && _numPag != 7)
        {
            
            _checkPos = true;
            _agentPlayer.speed = 10;
            
            if(_mudaFase < 5)
            {
                _mudaFase++;
            }

            if(_mudaFase == 3)
            {
                _mudaFase++;
            }

        }
        else
        {
            _checkPos = false;
        }

        if(value.performed && !_checkPos && _podeAvanca && _numPag == 7)
        {
            _checkPos = true;
            _agentPlayer.speed = 10;

            if(_mudaFase < 5)
            {
                _mudaFase++;
            }
        }
    }

    public void SetTras(InputAction.CallbackContext value)
    {
        if (value.performed && !_checkPos && _podeAvanca && _numPag != 7)
        {
            _checkPos = true;
            _agentPlayer.speed = 10;
            
            if(_mudaFase > 0)
            {
                _mudaFase--;
            }

            if(_mudaFase == 3)
            {
                _mudaFase--;
            }
            
        }
        else
        {
            _checkPos = false;
        }

        if(value.performed && !_checkPos && _podeAvanca && _numPag == 7)
        {
            _checkPos = true;
            _agentPlayer.speed = 10;

            if(_mudaFase > 0)
            {
                _mudaFase--;
            }
        }

    }


    private void AnimacaoPlayerMap()
    {
      _anim.SetFloat("Input", _agentPlayer.speed);
    }


    private IEnumerator TempoParaMudarFase()
    {
        _agentPlayer.speed = 0;
        yield return new WaitForSeconds(.2f);
        _mudaFase++;
        yield return new WaitForSeconds(.2f);
        _agentPlayer.speed = 10;

    }

}
