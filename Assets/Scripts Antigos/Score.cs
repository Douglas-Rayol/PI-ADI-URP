using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] ControlaPlayerTest _pontos;
    [SerializeField] Text _score;

    

    private void Update()
    {
        _score.text = "Paginas: " + _pontos._paginas.ToString();
    }


}
