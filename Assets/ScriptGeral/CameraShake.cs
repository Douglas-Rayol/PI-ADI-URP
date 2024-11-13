using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CameraShake : MonoBehaviour
{

    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] float _forca;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shake()
    {
       impulseSource.GenerateImpulse(_forca * Vector3.one);
    }


}
