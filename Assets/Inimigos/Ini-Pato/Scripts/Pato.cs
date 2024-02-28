using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class Pato : MonoBehaviour {

    float _inicioRay, _distMax;
    [SerializeField] float _velociPato, _atakPato, _volta;

    [SerializeField] Vector3 _direcaoRay;
    [SerializeField] Transform _direcaoPato;
    [SerializeField] Rigidbody _rbPato;


    public Transform _alvo, _pointCast;
    [SerializeField] bool _posplayer;
    [SerializeField] float dist;
    [SerializeField] float distPlayer;

    void Start() {
       // myTransform = this.GetComponent<Transform>();

    }

    void Update() {
        dist = Vector3.Distance(_alvo.position, transform.position);
        if(dist< distPlayer && !_posplayer) {
        
            Voltar(_alvo);
            _velociPato = _velociPato + 1.5f;
            if (dist < 5) {
                _posplayer = true;
                _velociPato = _velociPato - 1.5f;
            }

        } else  {
            Voltar(_direcaoPato);
          
        }
    }
    void Voltar(Transform value) {
        transform.LookAt(value.position);
        transform.Rotate(new Vector3(0, 90, 0), Space.Self);//correcting the original rotation
        transform.position = Vector2.MoveTowards(transform.position, value.position, _velociPato * Time.deltaTime);

    }
}