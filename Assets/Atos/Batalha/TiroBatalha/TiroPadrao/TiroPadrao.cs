using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TiroPadrao : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] public int _direction;
    [SerializeField] float _speed;
    public int _dano;

    void FixedUpdate()
    {
        _rb.velocity = new Vector3(_direction * _speed, _rb.velocity.y, _rb.velocity.z);

        StartCoroutine(TempoDeSpawn(.8f));

    }

    IEnumerator TempoDeSpawn(float _tempoSpawn)
    {
        yield return new WaitForSeconds(_tempoSpawn);
        Destroy(gameObject);

        yield return TempoDeSpawn(8);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBatalha>()._vidaMin -= _dano;
            
            other.gameObject.GetComponent<PlayerBatalha>()._anim.SetTrigger("Hit");

            //Sistema de Shake da Camera - Tive que usar um componente do Cinemachine que o DOTWeen não funciona com esse Multiplayer
            Camera.main.GetComponent<CinemachineImpulseSource>().GenerateImpulse(Vector3.right * 20 * Time.deltaTime);
            
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Escudo"))
        {
            Destroy(gameObject);
        }
    }
}
