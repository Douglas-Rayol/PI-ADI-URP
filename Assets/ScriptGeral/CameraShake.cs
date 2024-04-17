using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{

    bool _checkAtiva;

    [SerializeField] Vector3 _positionReferencia;


    // Start is called before the first frame update
    void Start()
    {
        _positionReferencia = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if(_checkAtiva == true)
        {
            transform.localPosition = _positionReferencia;
            _checkAtiva = false;
        }

    }


    public void Shake()
    {
        
        StartCoroutine(TimeShake());
    }

    IEnumerator TimeShake()
    {
        transform.DOShakePosition(2, new Vector3(20, 10, 0), 50, 0, true);
        yield return new WaitForSeconds(2f);
        _checkAtiva = true;
        DOTween.KillAll();
    }


}
