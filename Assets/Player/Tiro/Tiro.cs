using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    
    [SerializeField] Rigidbody _rb;
    public int direction = 0;
    public float _speed;
    public float _tempoVida = 0;
    bool _ativaTempo;
    [SerializeField] float _timeRespanw;

    // Start is called before the first frame update
    void Start()
    {
        _ativaTempo = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _tempoVida += Time.deltaTime;

        if(_tempoVida >= 1)
        {
            gameObject.SetActive(false);
            _tempoVida = 0;
            
        }
        if(_ativaTempo == true)
        {
          _timeRespanw += Time.deltaTime;
          if (_timeRespanw >= 1)
          {
            _ativaTempo = false;
          }
        }

        _rb.velocity = new Vector3(direction * _speed, _rb.velocity.y, _rb.velocity.z);

    }
}
