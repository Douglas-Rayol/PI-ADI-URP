using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandeira : MonoBehaviour
{
    Animator _anim;
    [SerializeField] GameObject _particula;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _anim.SetTrigger("Bandeira");
            StartCoroutine(PartBandeira());
        }
    }

    IEnumerator PartBandeira()
    {
        yield return new WaitForSeconds(1f);
        _particula.SetActive(true);
    }
}
