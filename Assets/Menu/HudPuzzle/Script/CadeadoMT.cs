using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CadeadoMT: MonoBehaviour
{

    [Header("Calculo")]
    [SerializeField] private string[] _calculo;




    [SerializeField] private int _index = 0;


    [SerializeField] private int _result;

    [SerializeField] private TextMeshProUGUI _textoCalculo;
    [SerializeField] private TextMeshProUGUI _textoResultado;


    private void Start()
    {

        ShuffleString(_calculo);
        _textoCalculo.text = "" + _calculo[0];

    }

    private void Update()
    {


    }


    public void Adiciona()
    {
        _index += 1;
        

        if (_index >= 10)
        {
            _textoResultado.text = "" + _index;
        }
        else if(_index < 10)
        {
            _textoResultado.text = "0" + _index;
        }


    }

    public void Retirar()
    {
        _index -= 1;
        if(_index <= 0)
        {
            _index = 0;
        }

        if (_index >= 10)
        {
            _textoResultado.text = "" + _index;
        }
        else if (_index < 10)
        {
            _textoResultado.text = "0" + _index;
        }

    }

    public void Resultado()
    {
        if (_calculo[0] == "2+3")
        {
            if(_index == 5)
            {
                Debug.Log("Você acertou!");
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }

        else if (_calculo[0] == "8+2")
        {
            if (_index == 10)
            {
                Debug.Log("Você acertou!");
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }

        else if (_calculo[0] == "4+8")
        {
            if (_index == 12)
            {
                Debug.Log("Você acertou!");
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }
        else if (_calculo[0] == "6-2")
        {
            if (_index == 4)
            {
                Debug.Log("Você acertou!");
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }
        else if (_calculo[0] == "4-4")
        {
            if (_index == 0)
            {
                Debug.Log("Você acertou!");
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }
        else if (_calculo[0] == "7-2")
        {
            if (_index == 5)
            {
                Debug.Log("Você acertou!");
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }
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
