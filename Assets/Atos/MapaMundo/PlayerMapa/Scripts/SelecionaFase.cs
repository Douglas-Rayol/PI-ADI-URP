using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;

public class SelecionaFase : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] Button _button0;
    [SerializeField] GameObject _particula;
    [SerializeField] public PlayerMap _playerMap;
    [SerializeField] ColetaConf _coletaPagina;

    public void PointFase1(int index)
    {
        PlayerPrefs.SetInt("fase1point", index);
        
         PlayerPrefs.DeleteKey("posX");
         PlayerPrefs.DeleteKey("posY");
         PlayerPrefs.DeleteKey("posZ");

         PlayerPrefs.SetFloat("posXMapa", _playerMap.transform.localPosition.x);
         PlayerPrefs.SetFloat("posYMapa", _playerMap.transform.localPosition.y);
         PlayerPrefs.SetFloat("posZMapa", _playerMap.transform.localPosition.z);
        


    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _playerMap._agentPlayer.speed = 0;
            _playerMap._podeAvanca = false;
            _button.Select();
            _particula.SetActive(true);
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _button0.Select();
            _particula.SetActive(false);
        }
    }

    public void EntraNoLoading() //Entra sempre no Loading
    {
        SceneManager.LoadScene(7);
        PlayerPrefs.SetInt("Salvou", 0);
        _coletaPagina._totalPag -= 6;

    }

    public void CenaLoad(int load) //Escolhe qual a fase que ele vai entrar
    {

        PlayerPrefs.SetInt("loadingCena", load);
        
        
    }
}
