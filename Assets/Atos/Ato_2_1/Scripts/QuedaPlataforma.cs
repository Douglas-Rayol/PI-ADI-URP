using System.Collections;

using UnityEngine;



public class QuedaPlataforma : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    float _gravidade;
    Vector3 _posicao;
    

    void Start(){
        rb.GetComponent<Rigidbody>();
        _posicao = transform.position;

    

     }

    IEnumerator Queda(){
        yield return new WaitForSeconds(0.5f);
        rb.isKinematic = false;
  
        yield return new WaitForSeconds(3.5f);
        transform.position = _posicao;
        rb.isKinematic = true;

    }
 
     private void OnCollisionEnter(Collision col) {
          if (col.gameObject.CompareTag("Player")){
            StartCoroutine(Queda());
        }

    }

}
