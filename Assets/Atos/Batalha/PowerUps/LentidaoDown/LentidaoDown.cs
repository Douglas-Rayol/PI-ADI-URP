using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LentidaoDown : MonoBehaviour
{

    [SerializeField] Rigidbody _rb;
    [SerializeField] float _gravidade;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.AddForce(Vector3.down * _gravidade);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Coroutine coroutine = collision.gameObject.GetComponent<PowerUpsJogador>().StartCoroutine("LentidaoPlayerDown", collision);

            Destroy(gameObject);

        }
    }



}

