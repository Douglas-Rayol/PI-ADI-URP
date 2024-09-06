using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Gira_Sem_Parar_Anti_Horario : MonoBehaviour{

       public float velocidadeRotacao = 20f;

    void Update()
    {
        // Rotaciona o objeto no eixo Y continuamente
        transform.Rotate( 0,0,velocidadeRotacao * Time.deltaTime);
    }

}
