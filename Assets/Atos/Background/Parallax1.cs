using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax1 : MonoBehaviour
{
    public Transform _alvo;
    public float _velocidadeRelativa;
    float _posicaoAntX;

    // Start is called before the first frame update
    void Start()
    {
        if (_velocidadeRelativa < 1)
        {
            _velocidadeRelativa = 1;
        }
        _alvo = GameObject.FindGameObjectWithTag("Player").transform;
        _posicaoAntX = _alvo.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        EfeitoParallax();
    }

    void EfeitoParallax()
    {
        transform.Translate((_alvo.position.x - _posicaoAntX) / _velocidadeRelativa, 0, 0);
        _posicaoAntX = _alvo.position.x;
    }
}
