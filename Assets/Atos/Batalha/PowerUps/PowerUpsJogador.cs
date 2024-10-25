using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsJogador : MonoBehaviour
{
    public IEnumerator VelocidadePlayerUp(Collision other)
    {
        other.gameObject.GetComponent<PlayerBatalha>()._speed += 20f;
        yield return new WaitForSeconds(10);
        other.gameObject.GetComponent<PlayerBatalha>()._speed -= 20f;
    }

    public IEnumerator UpPlayerDano(Collision other)
    {
        other.gameObject.GetComponent<SpawnTiro>()._tiroPlayer.GetComponent<TiroPadrao>()._dano += 3;
        yield return new WaitForSeconds(10);
        other.gameObject.GetComponent<SpawnTiro>()._tiroPlayer.GetComponent<TiroPadrao>()._dano -= 3;

    }
    
    public IEnumerator UpPlayerInvisivel(Collision other)
    {
        other.gameObject.GetComponent<SkinPlayer>()._skinIndie.SetActive(false);
        other.gameObject.GetComponent<PlayerBatalha>()._sprite.enabled = false;
        yield return new WaitForSeconds(10);
        other.gameObject.GetComponent<SkinPlayer>()._skinIndie.SetActive(true);
        other.gameObject.GetComponent<PlayerBatalha>()._sprite.enabled = true;
    }


}
