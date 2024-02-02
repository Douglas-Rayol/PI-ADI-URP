using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("Hud Vida do Jogador")]
    [SerializeField] PlayerController _vidaJogador;
    [SerializeField] GameObject[] _hudVida;

    [Header("Coisas pro Futuro")]
    [SerializeField] int variavelNada;

    [Header("Sistema de vida Cogula")]
    [SerializeField] public int _vidaCogula;
    //Barra de vida Cogula
    public Transform _barCheio; //barra verde
    public GameObject _barraVida; //barra principal(pai)
    private Vector3 _barScale; //tamanho da barra
    private float _barPercent; //calcula o percentual da vida do tamanho da barra

    [Header("Sistema de vida Cogula")]
    [SerializeField] public int _vidaBacon;
    // Start is called before the first frame update
    void Start()
    {
        _vidaJogador = FindObjectOfType<PlayerController>();
        // barra de vida cogula
        _barScale = _barCheio.localScale;
        _barPercent = _barScale.x / _vidaCogula;
        _barraVida.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        VidaDoJogadorHud();
        BarraDevida();
    }

    void VidaDoJogadorHud()
    {
        if(_vidaJogador._vida == 2)
        {
            _hudVida[2].SetActive(false);
        }

        if(_vidaJogador._vida == 1)
        {
            _hudVida[1].SetActive(false);
        }

        if (_vidaJogador._vida == 0)
        {
            _hudVida[0].SetActive(false);
        }

    }

    public void AplicarDano()
    {
        _barraVida.SetActive(true);
        _vidaCogula -= 1;

        if(_vidaCogula <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void BarraDevida()
    {
        _barScale.x = _barPercent * _vidaCogula;
        _barCheio.localScale = _barScale;
    }
}
