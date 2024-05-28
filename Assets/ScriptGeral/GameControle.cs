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

    public Text _textPagScore;
    public int _salvaScore;

    [SerializeField] ColetaConf _coletaConf;
    

    private void Start()
    {
        _salvaScore = PlayerPrefs.GetInt("SalvaPaginaScore");
        _coletaConf._totalPag = _salvaScore;
    }


    private void Update()
    {

        _textPagScore.text = "" + _salvaScore;

        if(Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("SalvaPaginaScore");
        }


    }

}
