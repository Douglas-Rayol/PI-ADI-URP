using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Pato : MonoBehaviour {

    public GameManager _pausaJogo;

    [SerializeField] float _velociPato;
    [SerializeField] Transform _direcaoPato;
    [SerializeField] float dist;
    [SerializeField] float distPlayer;
    [SerializeField] bool _posplayer;
    [SerializeField] SpriteRenderer _alerta;
    public Transform _alvo;
    Rigidbody _rbPato;

    bool _iniVeloPato;

    [SerializeField] GameObject _boxAlerta;

    void Start() 
    {
        _pausaJogo = FindAnyObjectByType<GameManager>();
    }

    void Update() {


        if(_pausaJogo._pause == false && _iniVeloPato == true)
        {
            dist = Vector3.Distance(_alvo.position, transform.position);
            if (dist < distPlayer && !_posplayer)
            {

                Voltar(_alvo);
                _velociPato = _velociPato + 1.2f;
                if (dist < 5)
                {
                    _posplayer = true;
                    _velociPato = _velociPato - 1.2f;
                }

            }
            else
            {
                Voltar(_direcaoPato);

            }
        }

    }
    void Voltar(Transform value) {
        transform.LookAt(value.position);
        transform.Rotate(new Vector3(0, 90, 0), Space.Self);//correcting the original rotation
        transform.position = Vector2.MoveTowards(transform.position, value.position, _velociPato * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (_pausaJogo._pause == false)
            {
                _iniVeloPato = true;
                if (_iniVeloPato == true)
                {
                    StartCoroutine(Alerta());
                    Destroy(_boxAlerta);
                }
            }
        }
    }
    

    IEnumerator Alerta()
    {
        _alerta.enabled = true;
        yield return new WaitForSeconds(.5f);
        _alerta.enabled = false;
        yield return new WaitForSeconds(.5f);
        _alerta.enabled = true;
        yield return new WaitForSeconds(.5f);
        _alerta.enabled = false;
        yield return new WaitForSeconds(.5f);
        _alerta.enabled = true;
        yield return new WaitForSeconds(.5f);
        _alerta.enabled = false;
        yield return new WaitForSeconds(.5f);
        _alerta.enabled = true;
        yield return new WaitForSeconds(.5f);
        _alerta.enabled = false;
        yield return new WaitForSeconds(.5f);
        _alerta.enabled = true;
        yield return new WaitForSeconds(.5f);
        _alerta.enabled = false;
        yield return new WaitForSeconds(1f);

    }
}