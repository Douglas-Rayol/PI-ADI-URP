using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    [SerializeField] public bool _abrir;
    [SerializeField] public Animator _anim;

    [SerializeField] public GameObject _seta;

    public  bool  _desativa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _abrir = true;
            
            if(_desativa == false)
            {
                _seta.SetActive(true);
            }
            else
            {
                _seta.SetActive(false);
            }
           

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            _abrir = false;
            _seta.SetActive(false);

        }
    }

}
