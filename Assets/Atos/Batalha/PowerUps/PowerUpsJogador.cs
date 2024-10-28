using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsJogador : MonoBehaviour
{
    [SerializeField] public GameObject _escudoPlayer;

    public IEnumerator VelocidadePlayerUp(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerBatalha>()._speed += 20f;
        yield return new WaitForSeconds(10);
        collision.gameObject.GetComponent<PlayerBatalha>()._speed -= 20f;
    }

    public IEnumerator LentidaoPlayerDown(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerBatalha>()._gravidade += 65;
        collision.gameObject.GetComponent<PlayerBatalha>()._speed -= 15f;
        yield return new WaitForSeconds(20);
        collision.gameObject.GetComponent<PlayerBatalha>()._gravidade -= 65;
        collision.gameObject.GetComponent<PlayerBatalha>()._speed += 15f;
    }

    public IEnumerator UpPlayerDano(Collision collision)
    {
        collision.gameObject.GetComponent<SpawnTiro>()._tiroPlayer.GetComponent<TiroPadrao>()._dano += 3;
        yield return new WaitForSeconds(10);
        collision.gameObject.GetComponent<SpawnTiro>()._tiroPlayer.GetComponent<TiroPadrao>()._dano -= 3;

    }
    
    public IEnumerator UpPlayerInvisivel(Collision collision)
    {
        collision.gameObject.GetComponent<SkinPlayer>()._skinIndie.SetActive(false);
        collision.gameObject.GetComponent<PlayerBatalha>()._sprite.enabled = false;
        yield return new WaitForSeconds(10);
        collision.gameObject.GetComponent<SkinPlayer>()._skinIndie.SetActive(true);
        collision.gameObject.GetComponent<PlayerBatalha>()._sprite.enabled = true;
    }

    public IEnumerator UpPlayerVida(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerBatalha>()._vidaMin += 15;
        yield return new WaitForSeconds(10);
    }

    public IEnumerator UpEscudoPlayer(Collision collision)
    {
        collision.gameObject.GetComponent<PowerUpsJogador>()._escudoPlayer.SetActive(true);
        yield return new WaitForSeconds(10);
        collision.gameObject.GetComponent<PowerUpsJogador>()._escudoPlayer.SetActive(false);
    }

    public IEnumerator DownInverterPlayer(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerBatalha>()._inverterDirecao = true;
        collision.gameObject.GetComponent<PlayerBatalha>().PlayerMovimento();
        yield return new WaitForSeconds(20);
        collision.gameObject.GetComponent<PlayerBatalha>().PlayerMovimento();
        collision.gameObject.GetComponent<PlayerBatalha>()._inverterDirecao = false;
    }
 
}
