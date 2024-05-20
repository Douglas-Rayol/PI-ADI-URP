using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CadeadoMT: MonoBehaviour
{

    [SerializeField] public Bau _bau;
    [SerializeField] GameControle _gameControle;

    [SerializeField] public bool _chamaPuzzle;
    [SerializeField] public GameObject _puzzleHud;

    [Header("Calculo")]
    [SerializeField] private string[] _calculo;
    [SerializeField] private string _calculoTemp;
    public int _question;

    [SerializeField] private int _resultado = 0;


    [SerializeField] private int _result;

    [SerializeField] public TextMeshProUGUI _textoCalculo;
    [SerializeField] public TextMeshProUGUI _textoResultado;

    public bool _bauAberto;


    private void Start()
    {

        ShuffleString(_calculo);

        _gameControle = Camera.main.GetComponent<GameControle>();


    }

    private void Update()
    {
        if(_chamaPuzzle == true)
        {
            _puzzleHud.SetActive(true);
            _chamaPuzzle = false;

        }

    }

    public void ChamaQuestao(int value)
    {
        _textoCalculo.text = "" + _calculo[value];
        _calculoTemp = _calculo[value];


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
        if (_calculoTemp == "2+3")
        {
            if(_resultado == 5)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }

        else if (_calculoTemp == "8+2")
        {
            if (_resultado == 10)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }

        else if (_calculoTemp == "4+8")
        {
            if (_resultado == 12)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }
        else if (_calculoTemp == "6-2")
        {
            if (_resultado == 4)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }
        else if (_calculoTemp == "4-4")
        {
            if (_resultado == 0)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }
        else if (_calculoTemp == "7-2")
        {
            if (_resultado == 5)
            {
                AcertouPuzzle();
            }
            else
            {
                Debug.Log("Você errou!");
            }
        }
    }


    private void AcertouPuzzle()
    {
        _bauAberto = false;

        _bau._anim.SetBool("Aberto", true);
        _bau._seta.SetActive(false);
        _bau._desativa = true;
        _bau.GetComponent<BoxCollider>().enabled = false;
        _gameControle._playerController._pausaJogo._pause = false;

        _puzzleHud.SetActive(false);

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
