using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColetePag : MonoBehaviour
{

    [SerializeField] GameObject _particula;
    [SerializeField] Animator _anim;
    private BoxCollider _box;
    [SerializeField] int _tipoPag;

    [SerializeField] ColetaConf _coletaConf;

    [SerializeField] GameControle _gameControle;
    public GameObject hand;

    void Start()
    {
        hand = GameObject.Find("Hand");
        _gameControle = hand.GetComponent<GameControle>();
        _anim = GetComponent<Animator>();

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
            _anim.enabled = false;
            transform.DOMove(_gameControle._HudPaginaPosition.position, 1f, false);
            _box.enabled = false;
            StartCoroutine(Coletar());
            
            _coletaConf._totalPag += 1;
            _gameControle._salvaScore = _coletaConf._totalPag;
            PlayerPrefs.SetInt("SalvaPaginaScore", _coletaConf._totalPag);
            

        }
    }

    IEnumerator Coletar()
    {
        _particula.gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().DOFade(0f, .65f);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
