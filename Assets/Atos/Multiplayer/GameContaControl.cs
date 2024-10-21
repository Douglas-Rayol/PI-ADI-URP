using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContaControl : MonoBehaviour
{
    public List<int> _respList;
    public List<BlocoNumeros> _blocoNumerosList;

    void Start()
    {
        Invoke("Setbloconumber", 1);
    }

    
    void Update()
    {
        
    }

    public void Setbloconumber()
    {
        for (int i = 0; i < _blocoNumerosList.Count; i++)
        {
            _blocoNumerosList[i]._numeroBloco = _respList[i];
            _blocoNumerosList[i]._texBloco.text = "" + _respList[i];
        }
    }
}
