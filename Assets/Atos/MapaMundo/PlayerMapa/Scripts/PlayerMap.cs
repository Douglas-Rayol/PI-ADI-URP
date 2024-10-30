using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMap : MonoBehaviour
{
    
    
    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _anim;
    [SerializeField] public NavMeshAgent _agentPlayer;
    [SerializeField] Vector3 _move;
    [SerializeField] MapControle _mapControle;
    
    [SerializeField] public int _mudaFase;
    [SerializeField] public bool _podeAvanca;
    [SerializeField] public int _numPag;




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

        _numPag = PlayerPrefs.GetInt("SalvaPaginaScore");

        AnimacaoPlayerMap();

        float _distance = Vector3.Distance(transform.position, _mapControle._posFase[_mudaFase].position);

        if (_mudaFase >= 0)
        {
            _agentPlayer.SetDestination(_mapControle._posFase[_mudaFase].position);
        }

    }

    public void SetFrente(InputAction.CallbackContext value)
    {
        if (value.performed && _mudaFase != 3 && !_podeAvanca)
        {   
            StartCoroutine(TempoMudaFaseFrente());
        }
    }

    public void SetTras(InputAction.CallbackContext value)
    {
        if (value.performed && _mudaFase != 0 && !_podeAvanca)
        {
            StartCoroutine(TempoMudaFaseAtras());
        }
    }

    public void SetSpeedRun(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            PlayerPrefs.SetInt("AtivouSpeedRun", 1);
        }
    }

    public void SetStart(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            SceneManager.LoadScene("Menu");
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

    public IEnumerator TempoMudaFaseFrente()
    {
        if(_numPag == 0 && _mudaFase < 1)
        {
            _podeAvanca = true;
            _mudaFase++;
            yield return new WaitForSeconds(.3f);
            _agentPlayer.speed = 10;
        }
        else if(_numPag == 6 && _mudaFase < 2)
        {
            _podeAvanca = true;
            _mudaFase++;
            yield return new WaitForSeconds(.3f);
            _agentPlayer.speed = 10;
        }
        else if(_numPag == 12 && _mudaFase < 3)
        {
            _podeAvanca = true;
            _mudaFase++;
            yield return new WaitForSeconds(.3f);
            _agentPlayer.speed = 10;
        }

    }

    public IEnumerator TempoMudaFaseAtras()
    {
        _podeAvanca = true;
        _mudaFase--;
        yield return new WaitForSeconds(.3f);
        _agentPlayer.speed = 10;
    }

}
