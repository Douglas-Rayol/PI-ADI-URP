using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPadrao : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] public int _direction;
    [SerializeField] float _speed;

    void FixedUpdate()
    {
        _rb.velocity = new Vector3(_direction * _speed, _rb.velocity.y, _rb.velocity.z);

        StartCoroutine(TempoDeSpawn(.8f));
    }

    IEnumerator TempoDeSpawn(float _tempoSpawn)
    {
        yield return new WaitForSeconds(_tempoSpawn);
        gameObject.SetActive(false);

        yield return TempoDeSpawn(8);
    }
}
