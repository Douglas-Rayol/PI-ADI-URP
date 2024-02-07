using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Menu()
    {
        StartCoroutine(TempoMenu());
    }


    IEnumerator TempoMenu()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("menu");
    }


}
