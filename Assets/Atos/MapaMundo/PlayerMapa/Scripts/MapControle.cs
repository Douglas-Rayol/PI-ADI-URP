using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapControle : MonoBehaviour
{
    [SerializeField] public Transform[] _posFase;

    [SerializeField] Text _pagNum;


    private void Update()
    {
        _pagNum.text = "" + PlayerPrefs.GetInt("SalvaPaginaScore");
    }



}
