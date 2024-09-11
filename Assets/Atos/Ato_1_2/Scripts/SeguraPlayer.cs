using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguraPlayer : MonoBehaviour
{
       // Detecta quando o jogador entra na plataforma
    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Player")){
            collision.transform.SetParent(transform);
        }
    }
       private void OnCollisionExit(Collision collision){

        if (collision.gameObject.CompareTag("Player")){
            collision.transform.SetParent(null);
        }
    }
}
