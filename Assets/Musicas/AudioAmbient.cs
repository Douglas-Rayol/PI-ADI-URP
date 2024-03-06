using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmbient : MonoBehaviour
{

    public bool _ativaDestruicao;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        

    }

    // Update is called once per frame
    void Update()
    {
        if(_ativaDestruicao == true)
        {
            Destroy(transform.gameObject);
        }
    }
}
