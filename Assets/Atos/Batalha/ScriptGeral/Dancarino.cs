using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Dancarino : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _gravidade;
    [SerializeField] bool _checkPulo;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rb.AddForce(Vector3.down * _gravidade);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
           _rb.velocity = new Vector3(_rb.position.x, Random.Range(10f, 20f), _rb.position.z);
        }
    }
}
