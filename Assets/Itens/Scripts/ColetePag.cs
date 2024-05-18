using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetePag : MonoBehaviour
{

    [SerializeField] GameObject _particula;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Coletar());
        }
    }

    void OnTriggerExit(Collider other)
    {
        
    }

    IEnumerator Coletar()
    {
        _particula.gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        _particula.gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        gameObject.SetActive(false);
    }
}
