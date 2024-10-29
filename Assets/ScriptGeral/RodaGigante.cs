using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodaGigante : MonoBehaviour
{
    public float velocidadeRotacao = 20f;

    void Update()
    {
        // Rotaciona o objeto no eixo Y continuamente
        transform.Rotate(0,0, velocidadeRotacao * Time.deltaTime);
    }
}
