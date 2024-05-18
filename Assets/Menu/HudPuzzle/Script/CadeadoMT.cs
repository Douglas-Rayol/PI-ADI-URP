using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CadeadoMT: MonoBehaviour
{

    [SerializeField] Bau _bau;

    [SerializeField] public bool _chamaPuzzle;
    [SerializeField] GameObject _puzzleHud;

    [Header("Calculo")]
    [SerializeField] private string[] _calculo;

    [SerializeField] private int _resultado = 0;


    [SerializeField] private int _result;

    [SerializeField] private TextMeshProUGUI _textoCalculo;
    [SerializeField] private TextMeshProUGUI _textoResultado;


    private void Start()
    {

        ShuffleString(_calculo);
        _textoCalculo.text = "" + _calculo[0];

        _bau = FindObjectOfType<Bau>();


    }

    private void Update()
    {
        if(_chamaPuzzle == true)
        {
            _puzzleHud.SetActive(true);
            _chamaPuzzle = false;

        }

    }


    public void Adiciona()
    {
        _resultado += 1;
        

        if (_resultado >= 10)
        {
            _textoResultado.text = "" + _resultado;
        }
        else if(_resultado < 10)
        {
            _textoResultado.text = "0" + _resultado;
        }


    }

    public void Retirar()
    {
        _resultado -= 1;
        if(_resultado <= 0)
        {
            _resultado = 0;
        }

        if (_resultado >= 10)
        {
            _textoResultado.text = "" + _resultado;
        }
        else if (_resultado < 10)
        {
            _textoResultado.text = "0" + _resultado;
        }

    }

    public void Resultado()
    {
        if (_calculo[0] == "2+3")
        {
            if(_resultado == 5)
            {
                AcertouPuzzle();

            }
            else
            {
                Debug.Log("Voc� errou!");
            }
        }

        else if (_calculo[0] == "8+2")
        {
            if (_resultado == 10)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Voc� errou!");
            }
        }

        else if (_calculo[0] == "4+8")
        {
            if (_resultado == 12)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Voc� errou!");
            }
        }
        else if (_calculo[0] == "6-2")
        {
            if (_resultado == 4)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Voc� errou!");
            }
        }
        else if (_calculo[0] == "4-4")
        {
            if (_resultado == 0)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Voc� errou!");
            }
        }
        else if (_calculo[0] == "7-2")
        {
            if (_resultado == 5)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Voc� errou!");
            }
        }
    }


    private void AcertouPuzzle()
    {
        _puzzleHud.SetActive(false);

        _bau._anim.SetBool("Aberto", true);
        _bau._seta.SetActive(false);
        _bau._desativa = true;
        _bau._abrir = false;
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
