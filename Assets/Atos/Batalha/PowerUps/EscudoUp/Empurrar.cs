using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Empurrar : MonoBehaviour
{



    void FixedUpdate()
    {
        transform.Rotate(Vector3.left * 7);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBatalha>()._vidaMin -= 10; //Retira a vida
            other.gameObject.GetComponent<VibrationController>().VibrarAnim();

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
