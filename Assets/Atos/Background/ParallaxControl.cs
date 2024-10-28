using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxControl : MonoBehaviour
{
    Transform _cam;
    Vector3 _camStartPos;
    GameObject[] _backgrounds;
    Material[] _mat;
    float _distance;
    float[] _backSpeed;
    float _farthestBack;
    [Range(0.01f, 0.8f)]
    public float _parallaxSpeed;
    int _backCount;

    void Start()
    {
        _cam = Camera.main.transform;
        _camStartPos = _cam.position;
        _backCount = transform.childCount;
        _mat = new Material[_backCount];
        _backSpeed = new float[_backCount];
        _backgrounds = new GameObject[_backCount];

        for (int i = 0; i < _backCount; i++)
        {
            _backgrounds[i] = transform.GetChild(i).gameObject;
            _mat[i] = _backgrounds[i].GetComponent<Renderer>().material;
        }
        BankSpeedCalculate(_backCount);
    }

    void BankSpeedCalculate(int _backCount)
    {
        for (int i = 0; i < _backCount; i++)
        {
            if ((_backgrounds[i].transform.position.z - _cam.position.z) > _farthestBack)
            {
                _farthestBack = _backgrounds[i].transform.position.z - _cam.position.z;
            }
        }

        for (int i = 0; i < _backCount; i++)
        {
            _backSpeed[i] = 1 - (_backgrounds[i].transform.position.z - _cam.position.z) / _farthestBack;

        }
    }

    private void LateUpdate()
    {
        _distance = _cam.position.x - _camStartPos.x;
        transform.position = new Vector3(_cam.position.x, transform.position.y, transform.position.z);
        for (int i = 0; i < _backgrounds.Length; i++)
        {
            float _speed = _backSpeed[i] * _parallaxSpeed;
            _mat[i].SetTextureOffset("_MainTex", new Vector2(_distance, 0) * _speed);
        }
    }
}
