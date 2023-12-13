using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] Transform _object1;
    [SerializeField] Transform _pos1;

    // Start is called before the first frame update
    void Start()
    {
        _object1.DOMove(_pos1.position, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
