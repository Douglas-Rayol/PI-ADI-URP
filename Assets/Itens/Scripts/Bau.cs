using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{

    [SerializeField] CadeadoMT _cadeadoMT;
    [SerializeField] public Animator _anim;
    [SerializeField] public GameObject _seta;
    [SerializeField] GameControle _gamecontrole;
    BoxCollider _box;
    [SerializeField] public Transform _dropPag;
    [SerializeField] public GameObject _Pag;
    [SerializeField] public int _tipoBau;
    public  bool  _desativa;

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
            _seta.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            _gamecontrole._playerController._bauOn = false;
            _seta.SetActive(false);

        }
    }

    public void DropPag()
    {
        Instantiate(_dropPag, transform.position, transform.rotation);
        StartCoroutine(DropTime());
    }
    public IEnumerator DropTime()
    {
        yield return new WaitForSeconds(1f);
        _Pag.SetActive(true);
    }

}
