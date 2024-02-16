using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllMenuGame : MonoBehaviour
{
    [SerializeField] Transform[] _Iconvida;
    [SerializeField] Transform _TelaGameOver;

    // Start is called before the first frame update
    void Start()
    {
        // _Iconvida[2].DOScale(0, 0.5f);
    }

    public void CheckIconVida(int vida)
    {
        if (vida == 0)
        {
            _Iconvida[0].DOScale(0, 0.5f);
            _TelaGameOver.DOScale(1, 0.5f);
            //chamar tela GameOver
        }
        if (vida == 1)
        {
            _Iconvida[1].DOScale(0, 0.5f);
        }
        else if (vida == 2)
        {
            _Iconvida[2].DOScale(0, 0.5f);
        }

    }
}
