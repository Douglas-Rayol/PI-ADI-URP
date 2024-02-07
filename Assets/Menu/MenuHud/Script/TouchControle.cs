using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControle : MonoBehaviour
{

    [SerializeField] GameObject _touch;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TouchTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator TouchTime()
    {
        yield return new WaitForSeconds(2f);
        _touch.SetActive(true);
    }

}
