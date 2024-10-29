using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LentidaoDown : MonoBehaviour
{

    [SerializeField] Rigidbody _rb;
    [SerializeField] float _gravidade;
    [SerializeField] int _pulos;

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

        _pulos++;

        if(_pulos <= 2)
        {
            _rb.velocity = new Vector2(Random.Range(-15, 15), 15f);
        } 

        if (collision.gameObject.CompareTag("Player"))
        {
            
            collision.gameObject.GetComponent<HudPowerUp>()._ativaTempoSlow = true;

            collision.gameObject.GetComponent<PowerUpsJogador>().LentidaoDownPlayer(collision);

            if(collision.gameObject.GetComponent<HudPowerUp>()._timeSlowMin < collision.gameObject.GetComponent<HudPowerUp>()._timeSlowMax)
            {
                collision.gameObject.GetComponent<HudPowerUp>()._timeSlowMin += 10;
                collision.gameObject.GetComponent<HudPowerUp>()._timeSlowMax += 10;
            }
            else
            {
                collision.gameObject.GetComponent<HudPowerUp>()._timeSlowMin = 10;
                collision.gameObject.GetComponent<HudPowerUp>()._timeSlowMax = 10;
            }

            Destroy(gameObject);

        }
    }



}

