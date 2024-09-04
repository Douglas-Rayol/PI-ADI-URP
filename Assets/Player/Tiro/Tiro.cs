using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    [SerializeField] private PlayerController _player;


    [SerializeField] Rigidbody _rb;
    public int direction = 0;
    public float _speed;
    public float _tempoVida = 0;
    int index;
    [SerializeField] float _timeRespanw;
    [SerializeField] GameObject _particula, _particulaAtaque;
    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (_player._trocaS == 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            _particula.SetActive(false);
        }

        else if (_player._trocaS == 2)
        {
            transform.localScale = new Vector3(3, 3, 3);
            _particula.SetActive(true);
            _particulaAtaque.SetActive(true);
        }

        _tempoVida += Time.deltaTime;

        if (_tempoVida >= 0.8f)
        {
            gameObject.SetActive(false);
            _tempoVida = 0;

        }

        _rb.velocity = new Vector3(direction * _speed, _rb.velocity.y, _rb.velocity.z);

    }

    private void OnTriggerEnter(Collider other) //Desativa o tiro quando acerta o inimigo.
    {
        if (other.gameObject.CompareTag("AtaqueEnemy"))
        {
            gameObject.SetActive(false);
            _tempoVida = 0;
        }
    }

}
