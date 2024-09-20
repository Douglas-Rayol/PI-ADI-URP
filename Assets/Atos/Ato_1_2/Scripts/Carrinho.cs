using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrinho : MonoBehaviour
{

    [SerializeField] Rigidbody _rb;

    private void OnCollisionEnter(Collision collision){

        _rb.isKinematic = true;

        if (collision.gameObject.CompareTag("Player")){
            collision.transform.SetParent(transform);
            
        }
    }

 


}
