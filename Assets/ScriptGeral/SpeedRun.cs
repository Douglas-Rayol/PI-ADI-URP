using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpeedRun : MonoBehaviour
{
    [SerializeField] GameObject _speedRunHUD;
    [SerializeField] GameManager _gameManager;
    [SerializeField] public TextMeshProUGUI _cronometroTxt;
    [SerializeField] public TextMeshProUGUI _ultimoTempo;
    [SerializeField] public float _tempo;
    [SerializeField] public bool _paraTime;
    [SerializeField] string _resultado;

    

    void Awake()
    {
        _ultimoTempo.text = "" + PlayerPrefs.GetString("salvaCronometro");
    }

    void Start()
    {
        _gameManager = GetComponent<GameManager>();

        if(PlayerPrefs.HasKey("salvaTime"))
        {
            _tempo = PlayerPrefs.GetFloat("salvaTime");
        }
        
    }

    void Update()
    {
        AtivaSpeedRunHud();

        if(!_gameManager._pause)
        {
            if(!_paraTime)
            {
                _tempo += Time.deltaTime;

                int minutos = Mathf.FloorToInt(_tempo / 60F);
                int segundos = Mathf.FloorToInt(_tempo % 60F);
                int milissegundos = Mathf.FloorToInt((_tempo * 100F) % 100F);

                _cronometroTxt.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milissegundos);
                
            }
            else
            {
                _cronometroTxt.gameObject.SetActive(false);
                _resultado = _cronometroTxt.text;
                PlayerPrefs.SetString("salvaCronometro", _resultado);
            }
        }

    }

    private void AtivaSpeedRunHud() //Ativa a hud da SpeedRun
    {
        if(PlayerPrefs.HasKey("AtivouSpeedRun"))
        {
            _speedRunHUD.SetActive(true);
        }
        else
        {
            _speedRunHUD.SetActive(false);
        }
    }
}
