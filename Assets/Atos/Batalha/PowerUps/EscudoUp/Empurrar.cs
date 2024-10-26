using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Empurrar : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBatalha>()._vidaMin -= 10; //Retira a vida

            if(other.gameObject.transform.eulerAngles.y == 90)
            {
                other.gameObject.GetComponent<PlayerBatalha>()._rb.DOMove(new Vector3(other.gameObject.GetComponent<PlayerBatalha>()._rb.position.x - 30, 0, 0), .3f, false);

            }
            else
            {
                other.gameObject.GetComponent<PlayerBatalha>()._rb.DOMove(new Vector3(other.gameObject.GetComponent<PlayerBatalha>()._rb.position.x + 30, 0, 0), .3f, false);
            }
        }
    }
}