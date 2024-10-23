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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _anim.SetTrigger("Bandeira");
            StartCoroutine(PartBandeira());

            PlayerPrefs.SetFloat("posX", other.gameObject.transform.position.x);
            PlayerPrefs.SetFloat("posY", other.gameObject.transform.position.y);
            PlayerPrefs.SetFloat("posZ", other.gameObject.transform.position.z);

        }
    }

    IEnumerator PartBandeira()
    {
        yield return new WaitForSeconds(1f);
        _particula.SetActive(true);
    }
}
