using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiro : MonoBehaviour
{
    [SerializeField] public GameObject _tiroPlayer;
    [SerializeField] Transform _posTiro;

    public void Tiro()
    {
        VerificaDirecao();

        Instantiate(_tiroPlayer, _posTiro.position, Quaternion.identity);
    }

    private void VerificaDirecao()
    {
        if(transform.eulerAngles.y == 90)
        {
            _tiroPlayer.GetComponent<TiroPadrao>()._direction = 1;
        }
        else
        {
            _tiroPlayer.GetComponent<TiroPadrao>()._direction = -1;
        }
    }

}
