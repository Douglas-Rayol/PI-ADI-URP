using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] public GameControle _gameControle;
    public GameObject hand;
    private void Start()
    {
        hand = GameObject.Find("Hand");

        _gameControle = hand.GetComponent<GameControle>();
       // _gameControle = Camera.main.GetComponent<GameControle>();
        _gameControle._checkPoint = GetComponent<CheckPoint>();
    }


    public void SalvaPos()
    {
        PlayerPrefs.SetFloat("posX", _gameControle._playerController.transform.position.x);
        PlayerPrefs.SetFloat("posY", _gameControle._playerController.transform.position.y);
        PlayerPrefs.SetFloat("posZ", _gameControle._playerController.transform.position.z);
        PlayerPrefs.SetInt("Salvou", 1);
    }

    public void ReiniciaSalvePos()
    {
        _gameControle._painelGameOver.SetActive(false);
        _gameControle._playerController._ativadorMovimento = true;

        if (PlayerPrefs.GetInt("Salvou") == 1)
        {
            _gameControle._playerController.transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), PlayerPrefs.GetFloat("posZ"));
        }
        else
        {
            _gameControle._playerController.transform.position = _gameControle._playerController._posInicial;
        }
    }

    public void ApagaSave()
    {
        PlayerPrefs.DeleteKey("SalvaPaginaScore");
        PlayerPrefs.DeleteKey("posX");
        PlayerPrefs.DeleteKey("posY");
        PlayerPrefs.DeleteKey("posZ");
        PlayerPrefs.DeleteKey("Salvou");
    }
}
