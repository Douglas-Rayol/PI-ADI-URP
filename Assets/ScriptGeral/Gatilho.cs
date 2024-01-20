using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Gatilho : MonoBehaviour
{

    [SerializeField] private UnityEvent _OnEnter;
    [SerializeField] private UnityEvent _OnDano;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _OnEnter.Invoke();
        }

        if (other.gameObject.CompareTag("Inimigo1"))
        {
            _OnDano.Invoke();
        }

    }





}
