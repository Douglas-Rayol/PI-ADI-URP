using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapControle : MonoBehaviour
{
    [SerializeField] public Transform[] _posFase;
    [SerializeField] Text _pagNum;

    private void Update()
    {
        if(PlayerPrefs.GetInt("SalvaPaginaScore") < 10)
        {
            _pagNum.text = "0" + PlayerPrefs.GetInt("SalvaPaginaScore");
        }
        else
        {
            _pagNum.text = "" + PlayerPrefs.GetInt("SalvaPaginaScore");
        }
        
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene("Menu");
    }



}
