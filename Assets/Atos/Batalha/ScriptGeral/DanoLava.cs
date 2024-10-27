using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoLava : MonoBehaviour
{

    [SerializeField] bool _paraDano;

    [SerializeField] BatalhaControle _batalhaControle;

    void Awake()
    {
        _batalhaControle = Camera.main.GetComponent<BatalhaControle>();
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _paraDano = false;
            StartCoroutine(DanoDeLava(other));
        }
    }


    IEnumerator DanoDeLava(Collision other)
    {
        if(!_batalhaControle._pausaJogo)
        {
            if(!_paraDano)
            {
                yield return new WaitForSeconds(.5f);
                other.gameObject.GetComponent<PlayerBatalha>()._anim.SetTrigger("Hit");
                other.gameObject.GetComponent<PlayerBatalha>()._vidaMin -= 1f;

                yield return DanoDeLava(other);
            }
        }

    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _paraDano = true;
        }
    }
}
