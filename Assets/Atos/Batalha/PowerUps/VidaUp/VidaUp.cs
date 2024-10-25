using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaUp : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _gravidade;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.down * _gravidade);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Coroutine coroutine = collision.gameObject.GetComponent<PowerUpsJogador>().StartCoroutine("UpPlayerVida", collision);

            Destroy(gameObject);
        }
    }
}
