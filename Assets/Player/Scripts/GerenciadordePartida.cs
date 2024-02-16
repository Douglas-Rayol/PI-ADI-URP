using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadordePartida : MonoBehaviour
{
    private bool PartidaIniciada;

    private void Awake()
    {
        Time.timeScale = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (PartidaIniciada) return;

        if (Input.GetMouseButtonDown(0))
        {
            PartidaIniciada = true;
            Time.timeScale = 1;
        }

    }
    public void reiniciarpartida()
    {
        SceneManager.LoadScene(0);
    }
}
