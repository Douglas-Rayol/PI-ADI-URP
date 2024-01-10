using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Gatilho : MonoBehaviour
{

    [SerializeField] private UnityEvent _OnEnter;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _OnEnter.Invoke();
        }
    }


}
