using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;


public class Carrinho : MonoBehaviour
{

    [SerializeField] Rigidbody _rbPlayer;
    [SerializeField] Transform _carrinho;
    [SerializeField] float _ejeta = 100f;
    [SerializeField] MeshCollider cubo;
   

    //[SerializeField] SplineAnimate _spline;
 
    private void OnCollisionEnter(Collision collision){

        _rbPlayer.isKinematic = true;
        
            
        if (collision.gameObject.CompareTag("Player")){
            collision.transform.SetParent(transform);         


            _carrinho.GetComponent<SplineAnimate>().Play();

        StartCoroutine(Ejeta());


        }
        
    }
    

    Vector3 diagonal = (Vector3.up + Vector3.right).normalized; //ejeta na diagona - ao menos na teoria
    private IEnumerator Ejeta(){ //corrotina para fazer o player deixar de ser parente do carrinho

    yield return new WaitForSeconds(25f); // tempo tem que ser igual ou maior que o tempo de viagen do carrinho
    _carrinho.GetComponent<SplineAnimate>().Pause();
    _rbPlayer.isKinematic = false;
    _rbPlayer.transform.SetParent(null);
    _rbPlayer.GetComponent<Rigidbody>().AddForce(diagonal * _ejeta, ForceMode.Impulse);//ejeta o player 
    _rbPlayer.GetComponent<PlayerController>()._groundCount = 0; // tive que deixar a variavel publica para setar a contagam do chao pra 0 pois estava somando +1 quando era ejetado tocava no chao 
    cubo.GetComponent<MeshCollider>().enabled = false;//tira a colisao do carrinho
    this.GetComponent<BoxCollider>().enabled = false;//tira a colisao da plataforma dentro do carrinho onde o player fica





    }

      


}
