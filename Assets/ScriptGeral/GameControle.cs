using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameControle : MonoBehaviour
{
    //Variaves Globais
    public PlayerController _playerController;
    public CadeadoMT _cadeadoMT;

    
    public GameObject[] _btPuzzles;
    public EventSystem _eventButton;


    [SerializeField] public ColetaConf _coletaConf;

    public Text _scorePag;


    private void Update()
    {

        _scorePag.text = "" + _coletaConf._totalPag;


    }

}
