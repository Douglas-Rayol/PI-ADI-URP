using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : MonoBehaviour
{
    [SerializeField] Rigidbody _rbPedra;
    [SerializeField] float _gravidade;

    private void Start()
    {
        _rbPedra = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        _rbPedra.AddForce(Vector3.down * _gravidade);
    }


}
