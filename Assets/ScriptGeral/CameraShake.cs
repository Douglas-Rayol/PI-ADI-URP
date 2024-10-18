using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{

    [SerializeField] Transform _referencia;

    public void Shake()
    {
       _referencia.DOShakePosition(2, new Vector3(20, 10, 0), 50, 0, true);
    }



}
