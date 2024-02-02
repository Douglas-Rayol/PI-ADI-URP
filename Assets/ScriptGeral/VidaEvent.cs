using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaEvent : MonoBehaviour
{
    [SerializeField] UnityEvent _hpinimigo;
    [SerializeField] GameManager _vidaIniControle;

    private void Start()
    {
        _vidaIniControle = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AtaquePlayer"))
        {
            _hpinimigo.Invoke();
            if ( _vidaIniControle._vidaCogula <= 0)
            {
               transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
