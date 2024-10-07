using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EfeitoConfig : MonoBehaviour
{
    [SerializeField] GameObject[] _opcaosHud;

    [SerializeField] bool value;

    [SerializeField] Sprite[] _img;

    [Header("Todas as Variaveis do Som")]
    [SerializeField] Slider _sliderSom;
    [SerializeField] Image _imgFind;


    [Header("Todas as Variaveis do Efeitos")]
    [SerializeField] Slider _sliderEfect;
    [SerializeField] Image _imgFind2;



    public void OpcaoEfect()
    {
        value = !value;

        if(value)
        {
            for (int i = 0; i < _opcaosHud.Length; i++)
            {
                _opcaosHud[i].transform.DOScale(new Vector3(1, .6f, .6f), .3f);
            }
        }
        else
        {
            for (int i = 0; i < _opcaosHud.Length; i++)
            {
                _opcaosHud[i].transform.DOScale(new Vector3(0, 0, 0), .3f);
            }
        }


    }

    public void Som()
    { 

        if(_sliderSom.value == 1)
        {
            _imgFind.sprite = _img[0];
        }
        else
        {
            _imgFind.sprite = _img[1];
        }
        
    }

    public void Efeitos()
    {
        if (_sliderEfect.value == 1)
        {
            _imgFind2.sprite = _img[0];
        }
        else
        {
            _imgFind2.sprite = _img[1];
        }
    }

}
