using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] controllMenuGame _controllMenuGame;
    [SerializeField] int _quantVida;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hit")
        {
            _quantVida--;
            _controllMenuGame.CheckIconVida(_quantVida);
        }
    }
}
