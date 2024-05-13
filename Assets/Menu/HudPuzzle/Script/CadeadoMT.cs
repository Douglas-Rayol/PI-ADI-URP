using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CadeadoMT : MonoBehaviour
{
    [Header("Numeros e Resultado")]
    [SerializeField] private List<int> _num1 = new List<int>();
    [SerializeField] private List<int> _num2 = new List<int>();
    [SerializeField] private List<string> _sinais = new List<string>();
    [SerializeField] private int _result;

    [SerializeField] int sorteioNum1;
    [SerializeField] int sorteioNum2;

    [Header("Hud Text")]
    [SerializeField] private TextMeshProUGUI _textNum1;
    [SerializeField] private TextMeshProUGUI _textNum2;
    [SerializeField] private TextMeshProUGUI _textSinais;
    [SerializeField] private TextMeshProUGUI _textResultad;

    private void Start()
    {


        string sorteioSinal = _sinais[Random.Range(0, 2)];
        sorteioNum1 = Random.Range(_num1[0], _num1[9]);
        sorteioNum2 = Random.Range(_num2[0], _num2[9]);

        _textNum1.text = "" + sorteioNum1;
        _textNum2.text = "" + sorteioNum2;
        _textSinais.text = sorteioSinal;


        if (sorteioSinal == _sinais[0])
        {
            
            if(sorteioNum1 > sorteioNum2)
            {
                _result = sorteioNum1 + sorteioNum2;
                _textResultad.text = "" + _result;
            }
            
        }
        else if (sorteioSinal == _sinais[1])
        {
            if(sorteioNum1 > sorteioNum2)
            {
                _result = sorteioNum1 - sorteioNum2;
                _textResultad.text = "" + _result;
            }

        }
        else if (sorteioSinal == _sinais[2])
        {
            if(sorteioNum1 > sorteioNum2)
            {
                _result = sorteioNum1 * sorteioNum2;
                _textResultad.text = "" + _result;
            }

        }







    }
}
