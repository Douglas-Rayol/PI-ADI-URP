using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class P1move : MonoBehaviour
{
    public Vector3 _move;
    public float _speed;
    Rigidbody _rb;
    public TextMeshPro _textPlayer;
    public BlocoNumeros _blocoNumeros;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.velocity = _move * _speed;
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector3>().normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bloco"))
        {
            _blocoNumeros = other.gameObject.GetComponent<BlocoNumeros>();
            _textPlayer.text = "" + _blocoNumeros._numeroBloco;
        }
    }
}
