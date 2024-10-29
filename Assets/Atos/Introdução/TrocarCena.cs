using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{



    public void Loadscenes(string mudaFase)
   {
        //PlayerPrefs.SetInt("loadingCena", 3);
        SceneManager.LoadSceneAsync(mudaFase);
   }

}
