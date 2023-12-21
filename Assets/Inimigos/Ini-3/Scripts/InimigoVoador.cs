using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVoador : MonoBehaviour {


	[SerializeField] private Transform _alvo;
	[SerializeField] private float _speedPato, _velociPato;
	[SerializeField] private Rigidbody _rbPato;
	[SerializeField] SpriteRenderer _flipPato;
	public Transform _pointCast;

	[SerializeField] LayerMask layerMask;

	//[SerializeField] bool test = false;

	void Start() {

	}

	void Update() {
		//ProcuraPlayer

		//FlipPato();


	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			StartCoroutine(TesteDoido());
		} else if (this._alvo = null) {

			transform.Translate(Vector3.left * this._velociPato * Time.deltaTime);
			} else {
			Vector3 _posicaoAlvo = this._alvo.position;
			Vector3 _posicaoAtual = this.transform.position;
			Vector3 _direcao = _posicaoAlvo - _posicaoAtual;
			_direcao = _direcao.normalized;
			this._rbPato.velocity = (this._speedPato * _direcao);
			}	
		}


		IEnumerator TesteDoido() {
			transform.DOMove(_alvo.position, 2f);

			yield return new WaitForSeconds(1f);
			/*
			DOTween.Kill(transform);
			yield return new WaitForSeconds(1f);
			Debug.Log("test");
			test = true;

		}



		//private void ProcuraPlayer() {

		//	Vector3 Direction = default;
		//	RaycastHit hit = Physics.Raycast(_pointCast.position,  _pointCast.TransformDirection(Vector3.down), 10f);

		//	if (hit.transform != null) {
		//		float _distance = Vector3.Distance(_pointCast.position, hit.point);
		//		Debug.DrawRay(_pointCast.position, _pointCast.TransformDirection(Vector3.down) * _distance, Color.red); //visualiza o raycast
		//		Debug.Log(hit.transform.name);  //mostra com o que o raycast esta colidindo


		//		//se o raycast hitar o player o pato vai na direcao dele
		//		if (hit.transform.CompareTag("Player")) {
		//			this._alvo = hit.transform;

		//			Vector3 _posicaoAlvo = this._alvo.position;
		//			Vector3 _posicaoAtual = this.transform.position;
		//			Vector3 _direcao = _posicaoAlvo - _posicaoAtual;
		//			_direcao = _direcao.normalized;

		//			this._rbPato.velocity = (this._speedPato * _direcao);
		//		} else {
		//			this._alvo = null;
		//			transform.Translate(Vector3.left * this._velociPato * Time.deltaTime);


		//		}
		//	} else {
		//		this._alvo = null;
		//		transform.Translate(Vector3.left * this._velociPato * Time.deltaTime);
		//	}
		//}

		//-------Flip------

		/*	
			private void FlipPato() {
			if (this._rbPato.velocity.x > 0) {
				this._flipPato.flipX = true;
			} else if (this._rbPato.velocity.x < 0) {
				this._flipPato.flipX = false;
			}
		}
		*/
		}
	}


