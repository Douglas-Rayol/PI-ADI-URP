using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class SelecionaFase : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] Button _button0;

    [SerializeField] PlayerMap _playerMap;



    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _playerMap._agentPlayer.speed = 0;
            _playerMap._podeAvanca = true;
            _button.Select();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _playerMap._agentPlayer.speed = 10;
            _playerMap._podeAvanca = false;
            _button0.Select();
        }
    }

    public void EntrarNaFase(string fase)
    {
        SceneManager.LoadSceneAsync(fase);
    }
}
