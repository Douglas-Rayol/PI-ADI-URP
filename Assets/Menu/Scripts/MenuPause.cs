using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject config;
    [SerializeField] private GameObject pause;
    
    public void AbrirPause()
    {
        config.SetActive(false);
        pause.SetActive(true);
    }
    public void fecharpause()
    {
        config.SetActive(true);
        pause.SetActive(false);
    }
   
   
}
