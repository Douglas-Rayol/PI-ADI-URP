using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciadordepartida : MonoBehaviour
{
    private bool PartidaIniada;

    private void Awake()
    {
        Time.timeScale = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        PartidaIniada = true;
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
