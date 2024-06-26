using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : MonoBehaviour
{
    [SerializeField] Rigidbody _rbPedra;
    [SerializeField] float _gravidade;
    [SerializeField] GameObject _particula;

    [SerializeField] Vector3 _posicao;

    private void Start() {
        _rbPedra = GetComponent<Rigidbody>();
        _posicao = transform.position;
    }


    private void FixedUpdate() {
        _rbPedra.AddForce(Vector3.down * _gravidade);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Morte")) {
            StartCoroutine(TempoRespawn());
        }
    }

    IEnumerator TempoRespawn() {
        yield return new WaitForSeconds(2f);
        _particula.SetActive(true);
        yield return new WaitForSeconds(.4f);
        transform.position = _posicao;
        _particula.SetActive(true);
        yield return new WaitForSeconds(.4f);
        _particula.SetActive(false);

    }
}
