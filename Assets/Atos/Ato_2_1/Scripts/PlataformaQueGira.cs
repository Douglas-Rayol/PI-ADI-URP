using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlataformaQueGira : MonoBehaviour
{
     Rigidbody rb;
     float _tempo;
     bool _gira;
    
    Vector3 _posicao;


    [SerializeField] Transform to;
    float speed = 0.01f;
    float timeCount = 0.0f;

    [SerializeField] bool checkRot;
    

    void Start(){
        rb.GetComponent<Rigidbody>();

     }

    IEnumerator Gira(){

        while(gameObject){
        yield return new WaitForSeconds(2f);
        transform.Rotate(new Vector3(0, 0, 180), 1f);
        }

    }

    private void Update (){

        _tempo += Time.deltaTime;

        if (_tempo >= 2.5f){
            checkRot=false;
            if(!checkRot){
                transform.Rotate(new Vector3(0,0,1));
            }
           
        }
        if (_tempo > 5){
            checkRot=true;
            _tempo = 0;
        }

        if(checkRot){
            rot();
        }
       

       // StartCoroutine(Gira());
    }


void rot(){
     transform.rotation = Quaternion.Lerp(transform.rotation, to.rotation, timeCount * speed);
    timeCount = timeCount + Time.deltaTime;
}


}

