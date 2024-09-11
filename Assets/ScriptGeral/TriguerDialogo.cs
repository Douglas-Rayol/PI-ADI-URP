using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriguerDialogo : MonoBehaviour
{
    public Dialogo _dialogo;
    public PainelTutorial _painelTutorial;

    private void Start()
    {
        _painelTutorial = Camera.main.GetComponent<PainelTutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _painelTutorial.PainelOn(true, _dialogo);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _painelTutorial.PainelOn(false, null);
        }
    }
}
