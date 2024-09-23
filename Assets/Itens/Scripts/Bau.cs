using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    [SerializeField] CadeadoMT _cadeadoMT;
    [SerializeField] public Animator _anim;
    [SerializeField] public GameObject _seta;
    [SerializeField] GameControle _gameControle;
    [SerializeField] public Transform _dropPag;
    [SerializeField] public GameObject _Pag;
    [SerializeField] GameObject _particula;
    [SerializeField] public int _tipoBau;
    [SerializeField] public int _bauaberto;

    public  bool  _desativa;
    BoxCollider _box;


    private void Start()
    {
        _cadeadoMT = Camera.main.GetComponent<CadeadoMT>();
        _gameControle = Camera.main.GetComponent<GameControle>();
        _box = GetComponent<BoxCollider>();

        _bauaberto = PlayerPrefs.GetInt("Bau" + _tipoBau);

        if (_bauaberto == 0)
        {
            _anim.SetBool("Aberto", false);
        }
        else if (_bauaberto == 1)
        {
            _anim.SetBool("Aberto", true);
            GetComponent<BoxCollider>().enabled = false;
        }


       

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _cadeadoMT._bau = GetComponent<Bau>(); //Envia o componente para a variavel publica do Bau no CadeadoMT.
            _gameControle._playerController._bauOn = true;
            _seta.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameControle._playerController._bauOn = false;
            _seta.SetActive(false);
        }
    }

    public void DropPag()
    {
        _gameControle.GetComponent<GameManager>()._pause = false;
        Instantiate(_dropPag, transform.position, transform.rotation);
        StartCoroutine(DropTime());
    }
    public IEnumerator DropTime()
    {
        yield return new WaitForSeconds(1f);
        _Pag.SetActive(true);
        yield return new WaitForSeconds(.2f);
        _particula.SetActive(true);
    }


}
