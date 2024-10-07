using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejetar : MonoBehaviour
{

    [SerializeField] Rigidbody _rbPlayer;
    [SerializeField] BoxCollider _bc;
     [SerializeField] float force = 50f;




    private void OnCollisionExit(Collision collision){

        _bc.GetComponent<BoxCollider>().enabled = false;
        _rbPlayer.isKinematic = false;

        if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
        } 
    }

/*


       private void OnCollisionExit(Collision collision){



        if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
        }   
    }

*/
   private void OnTriggerEnter(Collider other) {

        _rbPlayer.isKinematic = false;
        
        if (other.gameObject.CompareTag("Player")){
            other.transform.SetParent(null);
        }


          //  _anim.SetBool("trampolin", true);

     }
}


