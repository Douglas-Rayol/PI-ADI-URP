using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaEvent : MonoBehaviour
{
    [SerializeField] UnityEvent _hpinimigo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AtaquePlayer"))
        {
           // _hpinimigo.Invoke();
        }
    }
}
