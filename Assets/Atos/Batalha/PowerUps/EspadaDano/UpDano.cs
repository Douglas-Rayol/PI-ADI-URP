using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UpDano : MonoBehaviour
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

            collision.gameObject.GetComponent<PowerUpsJogador>().UpDanoPlayer(collision);

            collision.gameObject.GetComponent<HudPowerUp>()._ativaTempoDano = true;

            if(collision.gameObject.GetComponent<HudPowerUp>()._timeDanoMin < collision.gameObject.GetComponent<HudPowerUp>()._timeDanoMax)
            {
                collision.gameObject.GetComponent<HudPowerUp>()._timeDanoMin += 10;
                collision.gameObject.GetComponent<HudPowerUp>()._timeDanoMax += 10;
            }
            else
            {
                collision.gameObject.GetComponent<HudPowerUp>()._timeDanoMin = 10;
                collision.gameObject.GetComponent<HudPowerUp>()._timeDanoMax = 10;
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
