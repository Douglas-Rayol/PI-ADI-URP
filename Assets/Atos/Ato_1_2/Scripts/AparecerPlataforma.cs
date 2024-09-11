using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AparecerPlataforma : MonoBehaviour{
   
    public GameObject[] _ativarPlataformas;
    private bool _plataformaAtiva = false;



   public  void OnTriggerEnter(Collider other){

    
        
    if (other.CompareTag("Player") && !_plataformaAtiva){           
        AtivaPlataformas();            
    }
    

    void AtivaPlataformas(){

        _plataformaAtiva = true;

        foreach (GameObject plataforma in _ativarPlataformas){
        plataforma.SetActive(true);
       
        }
    }
   }
}