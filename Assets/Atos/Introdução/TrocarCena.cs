using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{

    public void Loadscenes(string Ato_1_1)
   {
        SceneManager.LoadScene(Ato_1_1);
   }

}
