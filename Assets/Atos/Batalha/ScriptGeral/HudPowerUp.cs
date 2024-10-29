using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudPowerUp : MonoBehaviour
{
    [Header("Variaveis dos Itens em Coodal na Hud")]
    [SerializeField] GameObject[] _itensHud;

    //Variavel do Escudo
    [SerializeField] public float _timeEscudoMin;
    [SerializeField] public float _timeEscudoMax;
    [SerializeField] public bool _ativaTempoEscudo;

    //Variavel do Dano
    [SerializeField] public float _timeDanoMin;
    [SerializeField] public float _timeDanoMax;
    [SerializeField] public bool _ativaTempoDano;

    //Variavel da Invisibilidade
    [SerializeField] public float _timeInvisibleMin;
    [SerializeField] public float _timeInvisibleMax;
    [SerializeField] public bool _ativaTempoInvisible;

    //Variavel da Lentidao
    [SerializeField] public float _timeSlowMin;
    [SerializeField] public float _timeSlowMax;
    [SerializeField] public bool _ativaTempoSlow;

    //Variavel da Velocidade
    [SerializeField] public float _timeVelocityMin;
    [SerializeField] public float _timeVelocityMax;
    [SerializeField] public bool _ativaTempoVelocity;

    //Variavel de Inverter
    [SerializeField] public float _timeInverterMin;
    [SerializeField] public float _timeInverterMax;
    [SerializeField] public bool _ativaTempoInverter;


 
    void Update()
    {
        if(_ativaTempoEscudo)
        {
            TimeEscudoHud();
        }
        else
        {
            GetComponent<PowerUpsJogador>()._escudoPlayer.SetActive(false);
            _timeEscudoMin = _timeEscudoMax;
            _itensHud[0].SetActive(false);
            _ativaTempoEscudo = false;
        }

        if(_ativaTempoDano)
        {
            TimeDanoHud();
        }

        if(_ativaTempoInvisible)
        {
            TimeInvisibleHud();
        }

        if(_ativaTempoSlow)
        {
            TimeSlowHud();
        }

        if(_ativaTempoVelocity)
        {
            TimeVelocityHud();
        }

        if(_ativaTempoInverter)
        {
            TimeInverterHud();
        }

    }

    private void TimeEscudoHud() 
    {
        _timeEscudoMin -= Time.deltaTime;

        if(_timeEscudoMin >= 0)
        {
            GetComponent<PowerUpsJogador>()._escudoPlayer.SetActive(true);
            _itensHud[0].SetActive(true);
            _itensHud[0].GetComponent<Image>().fillAmount = _timeEscudoMin / _timeEscudoMax;
        }
        else
        {
            GetComponent<PowerUpsJogador>()._escudoPlayer.SetActive(false);
            _timeEscudoMin = _timeEscudoMax;
            _itensHud[0].SetActive(false);
            _ativaTempoEscudo = false;
        }
    }

    private void TimeDanoHud() 
    {
        _timeDanoMin -= Time.deltaTime;

        if(_timeDanoMin >= 0)
        {
            _itensHud[1].SetActive(true);
            _itensHud[1].GetComponent<Image>().fillAmount = _timeDanoMin / _timeDanoMax;
        }
        else
        {
            GetComponent<SpawnTiro>()._tiroPlayer.GetComponent<TiroPadrao>()._dano = 2;
            _timeDanoMin = _timeDanoMax;
            _itensHud[1].SetActive(false);
            _ativaTempoDano = false;
        }
    }

    private void TimeInvisibleHud() 
    {
        _timeInvisibleMin -= Time.deltaTime;

        if(_timeInvisibleMin >= 0)
        {
            GetComponent<SkinPlayer>()._skinIndie.SetActive(false);
            GetComponent<PlayerBatalha>()._sprite.enabled = false;
            _itensHud[2].SetActive(true);
            _itensHud[2].GetComponent<Image>().fillAmount = _timeInvisibleMin / _timeInvisibleMax;
        }
        else
        {
            GetComponent<SkinPlayer>()._skinIndie.SetActive(true);
            GetComponent<PlayerBatalha>()._sprite.enabled = true;
            _timeInvisibleMin = _timeInvisibleMax;
            _itensHud[2].SetActive(false);
            _ativaTempoInvisible = false;
        }
    }

    private void TimeSlowHud()
    {
        _timeSlowMin -= Time.deltaTime;

        if(_timeSlowMin >= 0)
        {
            _itensHud[3].SetActive(true);
            _itensHud[3].GetComponent<Image>().fillAmount = _timeSlowMin / _timeSlowMax;
        }
        else
        {
            GetComponent<PlayerBatalha>()._gravidade -= 65;
            GetComponent<PlayerBatalha>()._speed += 15f;
            _timeSlowMin = _timeSlowMax;
            _itensHud[3].SetActive(false);
            _ativaTempoSlow = false;
        }
    }

    private void TimeVelocityHud()
    {
        _timeVelocityMin -= Time.deltaTime;

        if(_timeVelocityMin >= 0)
        {
            _itensHud[4].SetActive(true);
            _itensHud[4].GetComponent<Image>().fillAmount = _timeVelocityMin / _timeVelocityMax;
        }
        else
        {
            GetComponent<PlayerBatalha>()._speed -= 20f;
            _timeVelocityMin = _timeVelocityMax;
            _itensHud[4].SetActive(false);
            _ativaTempoVelocity = false;
        }
    }

    private void TimeInverterHud()
    {
        _timeInverterMin -= Time.deltaTime;

        if(_timeInverterMin >= 0)
        {
            GetComponent<PlayerBatalha>()._inverterDirecao = true;
            GetComponent<PlayerBatalha>().PlayerMovimento();
            _itensHud[5].SetActive(true);
            _itensHud[5].GetComponent<Image>().fillAmount = _timeInverterMin / _timeInverterMax;
        }
        else
        {
            GetComponent<PlayerBatalha>()._inverterDirecao = false;
            GetComponent<PlayerBatalha>().PlayerMovimento();
            _timeInverterMin = _timeInverterMax;
            _itensHud[5].SetActive(false);
            _ativaTempoInverter = false;
        }
    }
}
