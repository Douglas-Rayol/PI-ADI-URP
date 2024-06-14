using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{

    public void Loadscenes(string mudaFase)
   {
        SceneManager.LoadSceneAsync(mudaFase);
   }

}
