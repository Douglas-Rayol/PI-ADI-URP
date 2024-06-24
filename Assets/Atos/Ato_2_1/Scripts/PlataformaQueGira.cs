using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlataformaQueGira : MonoBehaviour
{
     Rigidbody rb;
    
    Vector3 _posicao;
    

    void Start(){
        rb.GetComponent<Rigidbody>();

     }

    IEnumerator Gira(){


           yield return new WaitForSeconds(2f);
           transform.DORotate(new Vector3(0, 0, 180), 1f);
           //transform.Rotate(new Vector3(0, 0, 180), 1f);
    

    

    }

    private void Update (){
        StartCoroutine(Gira());
    }




 /*     private void OnCollisionEnter(Collision col) {
          if (col.gameObject.CompareTag("Player")){
            StartCoroutine(Queda());
        }
    }
*/
}

