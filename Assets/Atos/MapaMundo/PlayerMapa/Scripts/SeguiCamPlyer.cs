using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguiCamPlyer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=_player.position;
    }
}
