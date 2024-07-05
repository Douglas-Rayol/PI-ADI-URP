using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gerenciadordepartida : MonoBehaviour
{
    private bool PartidaIniciada;
    [SerializeField] Button _buttonGameOver;
    [SerializeField] GameControle _gameControle;

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
    public void reiniciarpartida()
    {
        _gameControle._checkPoint.ReiniciaSalvePos();

    }
    public void MenuPrincipal()
    {
        _gameControle._checkPoint.ApagaSave();
        SceneManager.LoadScene("Menu");
        
    }

    public void MapaPrincipal()
    {
        _gameControle._checkPoint.ApagaSave();
        SceneManager.LoadScene("Mapa");

    }

    


}
