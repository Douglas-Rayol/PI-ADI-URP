using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlocoNumeros : MonoBehaviour
{
    public TextMeshPro _texBloco;
    public int _numeroBloco;

    void Start()
    {
        _texBloco.text = "" + _numeroBloco;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
