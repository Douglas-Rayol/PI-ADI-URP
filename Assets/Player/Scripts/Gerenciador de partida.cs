using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gerenciadordepartida : MonoBehaviour
{
    private bool PartidaIniciada;
    [SerializeField] Button _buttonGameOver;

    private void Awake()
    {

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
        SceneManager.LoadScene("Ato_1_1");
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
}
