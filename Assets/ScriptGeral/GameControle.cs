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

    [SerializeField] public GameObject[] _tutorialBau;

    [SerializeField] ColetaConf _coletaConf;
    

    private void Start()
    {
        _salvaScore = PlayerPrefs.GetInt("SalvaPaginaScore");
        _coletaConf._totalPag = _salvaScore;
    }


    private void Update()
    {

        _textPagScore.text = "" + _salvaScore;


    }

    public void AtivaBau()
    {
            _cadeadoMT._bauAberto = true;
            _cadeadoMT._puzzleHud.SetActive(true);
            _cadeadoMT.ChamaQuestao(_cadeadoMT._question);
            _cadeadoMT._question++;
            _playerController._pausaJogo._pause = true;


            _eventButton.firstSelectedGameObject = _btPuzzles[0]; //Faz o botão Cima do Puzzle ser o Primeiro do EventSystem
            _btPuzzles[0].GetComponent<Button>().Select();
    }

}
