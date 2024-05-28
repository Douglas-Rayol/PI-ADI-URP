using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColetePag : MonoBehaviour
{

    [SerializeField] GameObject _particula;
    private BoxCollider _box;


    [SerializeField] ColetaConf _coletaConf;

    [SerializeField] GameControle _gameControle;

    // Start is called before the first frame update
    void Start()
    {
        _gameControle = Camera.main.GetComponent<GameControle>();

        _box = GetComponent<BoxCollider>();
        _particula.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            _box.enabled = false;
            StartCoroutine(Coletar());
            
            _coletaConf._totalPag += 1;
            _gameControle._salvaScore = _coletaConf._totalPag;
            PlayerPrefs.SetInt("SalvaPaginaScore", _coletaConf._totalPag);
            

        }
    }

    IEnumerator Coletar()
    {
        _particula.gameObject.SetActive(true);
        yield return new WaitForSeconds(.1f);
        gameObject.SetActive(false);
    }
}
