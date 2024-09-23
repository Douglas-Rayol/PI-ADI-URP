using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class Carrinho : MonoBehaviour
{

    [SerializeField] Rigidbody _rbPlayer;
    [SerializeField] Transform _carrinho;
    



    private void OnCollisionEnter(Collision collision){

        _rbPlayer.isKinematic = true;
        
            
        if (collision.gameObject.CompareTag("Player")){
            collision.transform.SetParent(transform);
            
            _carrinho.GetComponent<SplineAnimate>().Play();


        }
           //_carrinho.GetComponent<SplineAnimate>().Play
    }


}
