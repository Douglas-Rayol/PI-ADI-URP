using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;


public class VidaCogula : MonoBehaviour
{
    public int _vida;
    public Transform _barCheio; //barra verde
    public GameObject _barraVida; //barra principal(pai)

    private Vector3 _barScale; //tamanho da barra
    private float _barPercent; //calcula o percentual da vida do tamanho da barra 
    // Start is called before the first frame update
    void Start()
    {
        _barScale = _barCheio.localScale;
        _barPercent = _barScale.x / _vida;
    }

    // Update is called once per frame
    void Update()
    {
        BarraDevida();
    }

    void BarraDevida()
    {
        _barScale.x = _barPercent * _vida;
        _barCheio.localScale = _barScale;
    }
}
