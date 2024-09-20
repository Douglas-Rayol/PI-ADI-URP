using DG.Tweening;
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
    public CheckPoint _checkPoint;
    public GameObject[] _btPuzzles;
    public EventSystem _eventButton;
    public GameObject _painelGameOver;
    public Gerenciadordepartida _gerenciadorDePartida;

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
