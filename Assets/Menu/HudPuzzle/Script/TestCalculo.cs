using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestCalculo : MonoBehaviour
{

    [Header("Calculo")]
    [SerializeField] private string[] _calculo;
    [SerializeField] private string _result;

    [SerializeField] private TextMeshProUGUI _textoCalculo;

    private void Start()
    {

        ShuffleString(_calculo);
        _textoCalculo.text = "" + _calculo[0] + " =";



        if (_calculo[0] == "2+3")
        {
            _result = "5";
            Debug.Log(_result);
        }

        else if (_calculo[0] == "8+2")
        {
            _result = "10";
            Debug.Log(_result);
        }

        else if (_calculo[0] == "4+8")
        {
            _result = "12";
            Debug.Log(_result);
        }




    }


    public void ResultadoDoCalculo()
    {

    }



    void ShuffleString(string[] lists)
    {
        for (int j = lists.Length - 1; j > 0; j--)
        {
            int rnd = UnityEngine.Random.Range(0, j + 1);
            string temp = lists[j];
            lists[j] = lists[rnd];
            lists[rnd] = temp;
        }
    }

}
