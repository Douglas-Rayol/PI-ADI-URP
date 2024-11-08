using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    [SerializeField] GameObject _particula;
    void Start()
    {
        StartCoroutine(PartSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PartSpawn()
    {
        yield return new WaitForSeconds(10f);
        _particula.SetActive(true);
        yield return new WaitForSeconds(1f);
        _particula.SetActive(false);
    }
}
