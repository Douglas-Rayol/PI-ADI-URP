using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionaFase : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
