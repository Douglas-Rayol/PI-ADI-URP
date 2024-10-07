using System.Collections;
using DG.Tweening;
using UnityEngine;



public class QuedaPlataforma : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    float _gravidade;
    Vector3 _posicao;
    [SerializeField] Vector3 _scaleIni;

    

    

    void Start(){
        rb.GetComponent<Rigidbody>();
        _posicao = transform.position;
        _scaleIni = transform.localScale;


     }

    private void Gravidade(){
        rb.AddForce(Vector3.down * 40f);
    }


    IEnumerator Queda(){
        //derruba plataforma
        yield return new WaitForSeconds(0.15f);
        rb.isKinematic = false;
        gameObject.GetComponent<MeshCollider>().enabled = false;


        yield return new WaitForSeconds(2f);
        rb.transform.DOScale(new Vector3(0,0,0), 1f);
       
  
        //restaura plataforma
        yield return new WaitForSeconds(1f);
        transform.position = _posicao;
        rb.isKinematic = true;
        gameObject.GetComponent<MeshCollider>().enabled = true;

        yield return new WaitForSeconds(2f);
        rb.transform.DOScale(_scaleIni, .25f);
        


    }
 
     private void OnCollisionEnter(Collision col) {
        
        
          if (col.gameObject.CompareTag("Player")){
           StartCoroutine(Queda());
           
           
        }
        

    }

private void Update(){
    Gravidade();
}


}
