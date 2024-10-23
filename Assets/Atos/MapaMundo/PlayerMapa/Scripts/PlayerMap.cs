using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    [SerializeField] int _checkqtdBonus;
    [SerializeField] int _numPag;

    [SerializeField] int _pagTest;

    [SerializeField] Vector3 _velocidade;



    void Start()
    {
        _mapControle = Camera.main.GetComponent<MapControle>();

        if (PlayerPrefs.GetInt("fase1point") == 1)
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("posXMapa"), PlayerPrefs.GetFloat("posYMapa"), PlayerPrefs.GetFloat("posZMapa"));
            _mudaFase = 1;
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        UnityEngine.Debug.Log(PlayerPrefs.GetInt("fase1point"));

        _numPag = PlayerPrefs.GetInt("SalvaPaginaScore");
        AnimacaoPlayerMap();

        float _distance = Vector3.Distance(transform.position, _mapControle._posFase[_mudaFase].position);

        _velocidade = _agentPlayer.velocity;

        if(_velocidade.x+ _velocidade.y + _velocidade.z==0)
        {
            _podeAvanca = true;
        }
        else
        {
            _podeAvanca = false;
        }


        if (_mudaFase >= 0)
        {
            _agentPlayer.SetDestination(_mapControle._posFase[_mudaFase].position);
            
        }


    }


    public void SetFrente(InputAction.CallbackContext value)
    {

        

        if (value.performed && !_checkPos && _podeAvanca)
        {
            
            _checkPos = true;
            _agentPlayer.speed = 10;

            if(_pagTest < 6 && _mudaFase == 2) //Não tem pagina
            {
                _mudaFase = 4;
            }
            else if(_pagTest >= 6 && _mudaFase == 2 && _checkqtdBonus == 0)
            {
                _mudaFase = 3;
                _checkqtdBonus = 1;
            }
            else if(_pagTest >= 6 && _mudaFase == 3 && _checkqtdBonus == 1)
            {
                _mudaFase = 2;
                _checkqtdBonus = 2;
            }
            else if(_pagTest >= 6 && _mudaFase == 2 && _checkqtdBonus == 2)
            {
                _mudaFase = 4;
                _checkqtdBonus = 0;
            }
            else
            {
                _mudaFase ++;
            }
             
            
            
            

        }
        else
        {
            _checkPos = false;
        }
    }

    public void SetTras(InputAction.CallbackContext value)
    {
        if (value.performed && !_checkPos && _podeAvanca && _mudaFase != 0)
        {
            _checkPos = true;
            _agentPlayer.speed = 10;

            if(_pagTest < 6 && _mudaFase == 2)
            {
                _mudaFase = 1;
            }
            else if(_pagTest >= 6 && _mudaFase == 4 && _checkqtdBonus == 0)
            {
                _mudaFase = 2;
                _checkqtdBonus = 1;
            }
            else if(_pagTest >= 6 && _mudaFase == 2 && _checkqtdBonus == 1)
            {
                _mudaFase = 1;
                _checkqtdBonus = 0;
            }
            else
            {
                if(_mudaFase!=0)
                _mudaFase --;
            }

        }
        else
        {
            _checkPos = false;
        }


    }

    public void SetSpeedRun(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            PlayerPrefs.SetInt("AtivouSpeedRun", 1);
        }
    }

    public void SetDeleteSaves(InputAction.CallbackContext value)
    {
        PlayerPrefs.DeleteAll();
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
