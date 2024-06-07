using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMap : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _anim;
    [SerializeField] float _speed;
    [SerializeField] public Vector3 _move;
    [SerializeField] private float _ultimaHorizontal;
    [SerializeField] bool _checkGround;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }
    public void SetMove(InputAction.CallbackContext value) //Jotap�
    {

        _move = value.ReadValue<Vector3>().normalized;

        
    }
    void Movimento()
    {
        _rb.velocity = new Vector3(_move.x * _speed, _rb.velocity.y, _move.y * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _checkGround = true;
            _anim.SetFloat("InputX", 1);
        }
    }
}
