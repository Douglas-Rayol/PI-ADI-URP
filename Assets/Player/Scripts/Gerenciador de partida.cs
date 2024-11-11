using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gerenciadordepartida : MonoBehaviour
{
    public bool PartidaIniciada;
    [SerializeField] Button _buttonGameOver;
    [SerializeField] GameControle _gameControle;

    [Header("Variaveis do Menu Start")]
    [SerializeField] Transform _menuStart;
    [SerializeField] GameObject[] _ativaButton;
    [SerializeField] public bool _startMenu;

    private void Awake()
    {
        _gameControle = Camera.main.GetComponent<GameControle>();
        _gameControle._gerenciadorDePartida = GetComponent<Gerenciadordepartida>();

        Time.timeScale = 0;
        Application.targetFrameRate = 60;

    }

    private void Start()
    {
        _buttonGameOver.Select();
    }

    // Update is called once per frame
    void Update()
    {
        PartidaIniciada = true;
        Time.timeScale = 1;
    }

    public IEnumerator AtivaStartMenu() //Ativa o Menu Start
    {
        GetComponent<GameManager>()._pause = true;

        for (int i = 0; i < _ativaButton.Length; i++)
        {
            _ativaButton[i].SetActive(true);
        }

        _menuStart.DOScale(1.6f, .3f);
        yield return new WaitForSeconds(.3f);
        _menuStart.DOScale(1.5f, .3f);
        
        _ativaButton[2].GetComponent<Button>().Select();
    }

    public IEnumerator DesativaStartMenu()
    {
        GetComponent<GameManager>()._pause = false;
        
        for (int i = 0; i < _ativaButton.Length; i++)
        {
            _ativaButton[i].SetActive(false);
        }

        _menuStart.DOScale(0f, .3f);
        yield return new WaitForSeconds(.3f);
    }
 
    public void GameMenuReiniar(string cena)
    {
        SceneManager.LoadScene(cena);

    }
    public void GameMenuPrincipal()
    {
        _gameControle._checkPoint.ApagaSave();
        SceneManager.LoadScene("Menu");
        
    }

    public void GameMapaPrincipal(int fasepoint)
    {
        if(PlayerPrefs.HasKey("fase1point"))
        {
            if(PlayerPrefs.GetInt("fase1point") == fasepoint)
            {
                SceneManager.LoadScene("Mapa");
                PlayerPrefs.DeleteKey("salvaTime");
            }
        }
        else
        {
            PlayerPrefs.DeleteKey("salvaTime");
            _gameControle._checkPoint.ApagaSave();
            SceneManager.LoadScene("Mapa");
        }

    }

    public void GameMenuReiniciarInicio(string cena)
    {
        //_gameControle._checkPoint.ApagaSave();

        if(PlayerPrefs.HasKey("AtivouSpeedRun")) //Temporario so para a SpeedRun
        {
            SceneManager.LoadScene(cena);

            PlayerPrefs.DeleteKey("posX");
            PlayerPrefs.DeleteKey("posY");
            PlayerPrefs.DeleteKey("posZ");
            PlayerPrefs.DeleteKey("salvaTime");

        }
        else
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(cena);
        }

    }




    


}
