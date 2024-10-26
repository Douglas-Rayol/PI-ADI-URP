using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilidadeUp : MonoBehaviour
{

    [SerializeField] Rigidbody _rb;
    [SerializeField] float _gravidade;
    [SerializeField] int _pulos;

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

        _pulos++;

        if(_pulos <= 2)
        {
            _rb.velocity = new Vector2(Random.Range(-15, 15), 15f);
        } 

        if(collision.gameObject.CompareTag("Player"))
        {
            Coroutine coroutine = collision.gameObject.GetComponent<PowerUpsJogador>().StartCoroutine("UpPlayerInvisivel", collision);
            Destroy(gameObject);
        }
    }
}
