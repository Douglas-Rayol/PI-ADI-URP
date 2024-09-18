using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrinho : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Player")){
            collision.transform.SetParent(transform);
        }
    }
}
