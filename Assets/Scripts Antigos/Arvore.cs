using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    [SerializeField] AudioSource _som;
    [SerializeField] Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
       _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _som.Play();
            _rb.useGravity = true;
        }
    }



}
