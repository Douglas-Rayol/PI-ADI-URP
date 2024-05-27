using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColetePag : MonoBehaviour
{

    [SerializeField] GameObject _particula;
    public int _pagScore;
    private BoxCollider _box;
    
    // Start is called before the first frame update
    void Start()
    {
        _box = GetComponent<BoxCollider>();
        _particula.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _box.enabled = false;
            StartCoroutine(Coletar());
            ControlePag._instance._totalPag += _pagScore;
            ControlePag._instance.UpdatePagText();
        }
    }

    IEnumerator Coletar()
    {
        _particula.gameObject.SetActive(true);
        yield return new WaitForSeconds(.1f);
        gameObject.SetActive(false);
    }
}
