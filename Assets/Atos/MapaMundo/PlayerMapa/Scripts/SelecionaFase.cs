using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelecionaFase : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] Button _button0;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _button.Select();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _button0.Select();
        }
    }

    public void EntrarNaFase(string fase)
    {
        SceneManager.LoadSceneAsync(fase);
    }
}
