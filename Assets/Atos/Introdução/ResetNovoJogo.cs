using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetaScore : MonoBehaviour
{
    [SerializeField] ColetaConf _coletaConf;


    private void Start()
    {
        _coletaConf._totalPag = 0;
    }

}
