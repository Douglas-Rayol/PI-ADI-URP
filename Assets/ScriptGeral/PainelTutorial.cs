using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class PainelTutorial : MonoBehaviour
{
    public TextMeshProUGUI _nomeTexto;
    public TextMeshProUGUI _contTexto;
    public Button _btFechar;
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
            _painelTutor.DOScale(1, .25f);
        }
        else
        {
            _painelTutor.DOScale(0, .25f);
        }
    }
}
