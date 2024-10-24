using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class Gerenciadordepartida : MonoBehaviour
{
    public bool PartidaIniciada;
    [SerializeField] Button _buttonGameOver;
    [SerializeField] GameControle _gameControle;
    public GameObject hand;

    private void Awake()
    {
        hand = GameObject.Find("Hand");
        
        _gameControle = hand.GetComponent<GameControle>();
       
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
    public void GameMenuReiniar()
    {
        SceneManager.LoadScene("Ato_1_1");

    }
    public void GameMenuPrincipal()
    {
        _gameControle._checkPoint.ApagaSave();
        SceneManager.LoadScene("Menu");
        
    }

    public void GameMapaPrincipal()
    {
        if(PlayerPrefs.GetInt("fase1point") == 1)
        {
            SceneManager.LoadScene("Mapa");
            PlayerPrefs.DeleteKey("salvaTime");
        }
        else
        {
            PlayerPrefs.DeleteKey("salvaTime");
            _gameControle._checkPoint.ApagaSave();
            SceneManager.LoadScene("Mapa");
        }

    }

    public void GameMenuReiniciarInicio()
    {
        //_gameControle._checkPoint.ApagaSave();

        if(PlayerPrefs.HasKey("AtivouSpeedRun")) //Temporario so para a SpeedRun
        {
            SceneManager.LoadScene("Ato_1_1");

            PlayerPrefs.DeleteKey("posX");
            PlayerPrefs.DeleteKey("posY");
            PlayerPrefs.DeleteKey("posZ");
            PlayerPrefs.DeleteKey("salvaTime");

        }
        else
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Ato_1_1");
        }

    }




    


}
