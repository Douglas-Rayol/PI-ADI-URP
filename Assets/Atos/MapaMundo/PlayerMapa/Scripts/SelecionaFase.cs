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
    [SerializeField] GameObject _particula;
    [SerializeField] public PlayerMap _playerMap;


    public void PointFase1(int index)
    {
        PlayerPrefs.SetInt("fase1point", index);

        PlayerPrefs.SetFloat("posXMapa", _playerMap.transform.position.x);
        PlayerPrefs.SetFloat("posYMapa", _playerMap.transform.position.y);
        PlayerPrefs.SetFloat("posZMapa", _playerMap.transform.position.z);

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

            _playerMap._agentPlayer.speed = 0;
            _button.Select();
            _particula.SetActive(true);
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _playerMap._agentPlayer.speed = 10;
            _button0.Select();
            _particula.SetActive(false);
        }
    }

    public void EntrarNaFase(string fase)
    {
        SceneManager.LoadSceneAsync(fase);
    }
}
