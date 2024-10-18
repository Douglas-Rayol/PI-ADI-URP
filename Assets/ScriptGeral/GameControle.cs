using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameControle : MonoBehaviour
{
    public DynamicJoystick _dynamicJoystick;
    public PlayerController _playerController;
    public CadeadoMT _cadeadoMT;
    public CheckPoint _checkPoint;
    public GameObject[] _btPuzzles;
    public EventSystem _eventButton;
    public GameObject _painelGameOver;
    public Gerenciadordepartida _gerenciadorDePartida;
    public Transform _HudPaginaPosition;

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
        GetComponent<GameManager>()._pause = true;

        _eventButton.firstSelectedGameObject = _btPuzzles[0]; //Faz o botão Cima do Puzzle ser o Primeiro do EventSystem
        _btPuzzles[0].GetComponent<Button>().Select();

        if(_btPuzzles[0])
        {
            _cadeadoMT._particulaDireita.SetActive(true);
            _cadeadoMT._particulaEsquerda.SetActive(false);
        }
        else if(_btPuzzles[1])
        {
            _cadeadoMT._particulaEsquerda.SetActive(true);
            _cadeadoMT._particulaDireita.SetActive(false);
        }


        
    }

    public void GameOver()
    {
        _playerController._ativadorMovimento = false;
        StartCoroutine(ExibirPainelGameOver());
    }


    private IEnumerator ExibirPainelGameOver()
    {
        yield return new WaitForSeconds(2f);
        _painelGameOver.SetActive(true);
        _painelGameOver.transform.DOScale(.8f, 1f);
        yield return new WaitForSeconds(1f);
        //DOTween.KillAll();
    }
}
