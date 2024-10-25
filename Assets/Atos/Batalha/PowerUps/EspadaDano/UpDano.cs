using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDano : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<SpawnTiro>()._tiroPlayer.GetComponent<TiroPadrao>()._dano = 2;

            Destroy(gameObject);
        }
    }
}
