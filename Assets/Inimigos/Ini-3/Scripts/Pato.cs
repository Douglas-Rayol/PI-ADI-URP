using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Pato : MonoBehaviour {

    float _inicioRay, _distMax;
    [SerializeField] float _speedPato, _velociPato;

	[SerializeField] Vector3 _direcaoRay;
    Rigidbody _rbPato;


	public Transform _alvo, _pointCast;


    void Update() {

        ProcuraPlayer();
 
	}

    private void ProcuraPlayer() {

		//RaycastHit hit =  Physics.Raycast(_pointCast.position,  _pointCast.TransformDirection(Vector3.down), out hit, 10f);

		//if (hit.transform != null) { }

        RaycastHit hit;
		if (Physics.Raycast(_pointCast.position, _pointCast.TransformDirection(Vector3.down), out hit, 25f))  {
		float _distancia = Vector3.Distance(_pointCast.position,  hit.point);

		    Debug.DrawRay(_pointCast.position, _pointCast.TransformDirection(Vector3.down) * _distancia, Color.red); //visualiza o raycast
		    Debug.Log(hit.transform.name);  //mostra com o que o raycast esta colidindo

            if (hit.transform.CompareTag("Player")) {
                this._alvo = hit.transform;

				transform.DOMove(_alvo.position, _speedPato);
				/*
				Vector3 _posicaoAlvo = this._alvo.position;
				Vector3 _posicaoAtual = this.transform.position;
				Vector3 _direcao = _posicaoAlvo - _posicaoAtual;
				_direcao = _direcao.normalized;
				
				this._rbPato.velocity = (this._speedPato * _direcao);
				*/

			} else {
                this._alvo = null;
				transform.Translate(Vector3.left * this._velociPato * Time.deltaTime);
			}
        } else {
            this._alvo = null;
			transform.Translate(Vector3.left * this._velociPato * Time.deltaTime);
		}
    }
}