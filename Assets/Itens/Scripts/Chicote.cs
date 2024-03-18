using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicote : MonoBehaviour
{


    [SerializeField] Animator _anim;


    

    public void ChicoteLigado()
    {
        _anim.SetBool("ativa", true);
        Invoke("DesligaChicote", 0.23f);
    }
    

    void DesligaChicote()
    {
        _anim.SetBool("ativa", false);
    }


}
