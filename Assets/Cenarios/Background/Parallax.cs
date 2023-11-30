using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _length;
    private float _startPos;
    
    [SerializeField] private Transform _Cm;

    public float ParalaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float RePos = _Cm.transform.position.x * (1 - ParalaxEffect);
        float Distance = _Cm.transform.position.x * ParalaxEffect;
        transform.position = new Vector3(_startPos + Distance,transform.position.y, transform.position.z);

        if(RePos > _startPos + _length)
        {
            _startPos += _length;
        }
        else if(RePos < _startPos - _length)
        {
            _startPos -= _length;
        }
    }
}
