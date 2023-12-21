using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPato : MonoBehaviour
{

    public Transform _pointCast;
    public Transform _alvo;
    
    void Start()
    {
        
    }

    void Update()
    {
        ProcuraPlayer();
    }

	private void ProcuraPlayer() {
        RaycastHit2D hit = Physics2D.Raycast(_pointCast.position, _pointCast.TransformDirection(Vector3.down), 10f);

        if (hit.transform != null ) {
            float _distance = Vector2.Distance(_pointCast.position, hit.point);
            Debug.DrawRay(_pointCast.position, _pointCast.TransformDirection(Vector3.down) * _distance, Color.red); //visualiza o raycast
            Debug.Log(hit.transform.name);  //mostra com o que o raycast esta colidindo

            if (hit.transform.CompareTag("Player")) {
                this._alvo = hit.transform;
            } else {
                this._alvo = null;
            }
        } else {
            this._alvo = null;
        }
	}



}
