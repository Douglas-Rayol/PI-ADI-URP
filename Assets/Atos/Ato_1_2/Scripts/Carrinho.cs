using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;


public class Carrinho : MonoBehaviour
{

    [SerializeField] Rigidbody _rbPlayer;
    [SerializeField] Transform _carrinho, _barreira2, _barreira1;
    [SerializeField] float _ejeta = 30f;
    [SerializeField] MeshCollider cubo;
   

    //[SerializeField] SplineAnimate _spline;
 
    private void OnCollisionEnter(Collision collision){

        _rbPlayer.isKinematic = true;
        
            
        if (collision.gameObject.CompareTag("Player")){
            collision.transform.SetParent(transform);   
            _rbPlayer.GetComponent<PlayerController>().enabled = false;  //desabilita os controles do player pro modelo 3d nao bugar tudo   
            _barreira1.GetComponent<BoxCollider>().enabled = true;
            _barreira2.GetComponent<BoxCollider>().enabled = false;

            _carrinho.GetComponent<SplineAnimate>().Play();

            _barreira1.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(Ejeta());

        }
        
    }
    

    Vector3 diagonal = (Vector3.up + Vector3.right).normalized * 2.5f; //ejeta na diagona - ao menos na teoria
    private IEnumerator Ejeta(){ //corrotina para fazer o player deixar de ser parente do carrinho

    yield return new WaitForSeconds(18f); // tempo tem que ser igual ou maior que o tempo de viagen do carrinho
        _carrinho.GetComponent<SplineAnimate>().Pause();
        _rbPlayer.GetComponent<PlayerController>().enabled = true; //habilita os controles do player
        _rbPlayer.isKinematic = false;
        _rbPlayer.transform.SetParent(null);
        _barreira2.GetComponent<BoxCollider>().enabled = true; // atica colisaor pro player nao se jogar do cenario
        _rbPlayer.GetComponent<Rigidbody>().AddForce(diagonal * _ejeta, ForceMode.Impulse);//ejeta o player 
        _rbPlayer.GetComponent<PlayerController>()._groundCount = 0; // tive que deixar a variavel publica para setar a contagam do chao pra 0 pois estava somando +1 quando era ejetado tocava no chao 
        _rbPlayer.GetComponent<PlayerController>()._plataforma = false; 
     
        cubo.GetComponent<MeshCollider>().enabled = false;//tira a colisao do carrinho
        this.GetComponent<BoxCollider>().enabled = false;//tira a colisao da plataforma dentro do carrinho onde o player fica

    }

}
