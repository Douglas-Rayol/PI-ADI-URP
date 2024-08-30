using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaLadeira : MonoBehaviour
{
    [SerializeField] GameControle _gameControle;

    private void Start()
    {
        _gameControle = Camera.main.GetComponent<GameControle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladeira"))
        {
            _gameControle._playerController._gravidade = 1500;
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            _gameControle._playerController._gravidade = 110;

        }
    }

}
