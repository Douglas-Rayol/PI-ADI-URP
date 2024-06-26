using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraPlataforma : MonoBehaviour
{
    public float rotacaoSpeed = 300f; // Velocidade de rotação em graus por segundo

    private void Start(){
        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine(){
        while(true){
            // Girar 180 graus
            yield return RotacionaAngulo(180);
                this.GetComponent<BoxCollider>().enabled = true;

            // Esperar 2 segundos
            yield return new WaitForSeconds(3.5f);
                this.GetComponent<BoxCollider>().enabled = false;

            // Girar mais 180 graus
            yield return RotacionaAngulo(180);
                this.GetComponent<BoxCollider>().enabled = true;
            
            // Esperar 2 segundos
            yield return new WaitForSeconds(3.5f);
                this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private IEnumerator RotacionaAngulo(float angulo){

        float recebeRotacao = 0;
        while (recebeRotacao <= angulo){

            float rotacaoPorFrame = rotacaoSpeed * Time.deltaTime;
            transform.Rotate(0,  0, rotacaoPorFrame);
            recebeRotacao += rotacaoPorFrame;
            yield return null;
        }

        // Corrigir rotação para garantir que tenha girado exatamente a quantidade desejada
        transform.Rotate(0,  0, angulo - recebeRotacao);
    }


}
