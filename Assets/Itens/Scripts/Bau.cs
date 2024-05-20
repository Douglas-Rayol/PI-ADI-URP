using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{

    [SerializeField] CadeadoMT _cadeadoMT;

    [SerializeField] public Animator _anim;

    [SerializeField] public GameObject _seta;

    public  bool  _desativa;

    [SerializeField] public int _tipoBau;

    [SerializeField] GameControle _gamecontrole;
    BoxCollider _box;

    private void Start()
    {
        _cadeadoMT = Camera.main.GetComponent<CadeadoMT>();
        _gamecontrole = Camera.main.GetComponent<GameControle>();
        _box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

            _cadeadoMT._bau = GetComponent<Bau>(); //Envia o componente para a variavel publica do Bau no CadeadoMT.
            _gamecontrole._playerController._bauOn = true;

            if (_desativa == false)
            {
                _seta.SetActive(true);
            }
            else
            {
                _seta.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            _gamecontrole._playerController._bauOn = false;

            _seta.SetActive(false);
            _box.GetComponent<BoxCollider>().enabled = false;

        }
    }

}
