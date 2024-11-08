using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriguerDialogo : MonoBehaviour
{
    public Dialogo _dialogo;
    public PainelTutorial _painelTutorial;

    [SerializeField] GameControle _gameControle;

    void Awake()
    {
        _gameControle = Camera.main.GetComponent<GameControle>();

        if(PlayerPrefs.HasKey("AtivouSpeedRun")) //Temporario pra SpeedRun Depois Retiramos
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        _painelTutorial = Camera.main.GetComponent<PainelTutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameControle._desativaStart = true;

            if(_dialogo._tipo == 0)
            {
                _painelTutorial.PainelOn(true, _dialogo);
                
            }
            else if(_dialogo._tipo == 1)
            {
                _painelTutorial.PainelPedra(true, _dialogo);
                
            }
            else if(_dialogo._tipo == 2)
            {
                _painelTutorial.PainelPagina(true, _dialogo);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameControle._desativaStart = false;
            
            _painelTutorial.PainelOn(false, null);
            _painelTutorial.PainelPedra(false, null);
            _painelTutorial.PainelPagina(false, null);
        }
    }
}
