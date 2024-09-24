using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class PainelTutorial : MonoBehaviour
{
    public TextMeshProUGUI _nomeTexto;
    public TextMeshProUGUI _contTexto,_contTexto2,_contTexto3;
    public Transform _painelTutor;

    public List<Dialogo> dialogos = new List<Dialogo>();

    void Start()
    {
        _painelTutor.localScale = Vector3.zero;
    }
    void Update()
    {
        
    }
    public void PainelOn(bool value, Dialogo dialogo)
    {
        if (value)
        {
            _nomeTexto.text = dialogo._nome;
            _contTexto.text = dialogo._texto;
            _contTexto2.text = dialogo._texto2;
            _contTexto3.text = dialogo._texto3;
            _painelTutor.DOScale(1, .25f);
        }
        else
        {
            _painelTutor.DOScale(0, .25f);
        }
    }
}
