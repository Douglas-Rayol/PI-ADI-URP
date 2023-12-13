using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mordida : MonoBehaviour
{

    [SerializeField] public Transform _pos;
    public Transform _pos2;


    [SerializeField] Animator _animInimigo;

    // Start is called before the first frame update
    void Start()
    {
        _animInimigo = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TempoMordida());

        }
    }


    IEnumerator TempoMordida()
    {
        _animInimigo.SetBool("fechada", true);
        _animInimigo.SetBool("aberta", false);
        yield return new WaitForSeconds(1f);
        _animInimigo.SetBool("aberta", true);
        _animInimigo.SetBool("fechada", false);

    }






}
