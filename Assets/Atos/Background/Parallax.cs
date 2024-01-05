using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _length;
    private float _startPos;
    
    [SerializeField] private Transform _Camera;
    [SerializeField] Transform _alvo;
    public float _ParalaxEffect;
    

    // Start is called before the first frame update
    void Start()
    { 
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
        _Camera = Camera.main.transform;
        _alvo = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float RePos = _Camera.transform.position.x * (1 - _ParalaxEffect);
        float Distance = _Camera.transform.position.x * _ParalaxEffect;
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
