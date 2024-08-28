using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounciness : MonoBehaviour
{

    //Trampolin
    [SerializeField] public Animator _anim;

    [SerializeField] float force = 10f;




    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);

            _anim.SetBool("flor", true);

        }
    }

    private void OnTriggerExit(Collider other) {
        _anim.SetBool("flor", false);
    }
}
