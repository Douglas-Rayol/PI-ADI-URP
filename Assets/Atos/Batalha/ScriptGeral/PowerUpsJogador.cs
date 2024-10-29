using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsJogador : MonoBehaviour
{
    [SerializeField] public GameObject _escudoPlayer;

    public void VelocidadePlayerUp(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerBatalha>()._speed += 20f;
    }

    public void LentidaoDownPlayer(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerBatalha>()._gravidade += 65;
        collision.gameObject.GetComponent<PlayerBatalha>()._speed -= 15f;
    }

    public void UpDanoPlayer(Collision collision)
    {
        collision.gameObject.GetComponent<SpawnTiro>()._tiroPlayer.GetComponent<TiroPadrao>()._dano += 3;
    }

    public IEnumerator UpPlayerVida(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerBatalha>()._vidaMin += 15;
        yield return new WaitForSeconds(10);
    }
 
}
