using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadeUp : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _gravidade;
    [SerializeField] int _pulos;
    [SerializeField] GameObject _particula;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(PartSpawn());
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
            collision.gameObject.GetComponent<HudPowerUp>()._ativaTempoVelocity = true;
            collision.gameObject.GetComponent<PowerUpsJogador>().VelocidadePlayerUp(collision);

            if(collision.gameObject.GetComponent<HudPowerUp>()._timeVelocityMin < collision.gameObject.GetComponent<HudPowerUp>()._timeVelocityMax)
            {
                collision.gameObject.GetComponent<HudPowerUp>()._timeVelocityMin += 10;
                collision.gameObject.GetComponent<HudPowerUp>()._timeVelocityMax += 10;
            }
            else
            {
                collision.gameObject.GetComponent<HudPowerUp>()._timeVelocityMin = 10;
                collision.gameObject.GetComponent<HudPowerUp>()._timeVelocityMax = 10;
            }

            Destroy(gameObject);
        }
    }
    IEnumerator PartSpawn()
    {
        _particula.SetActive(true);
        yield return new WaitForSeconds(.3f);
        _particula.SetActive(false);
    }
}
