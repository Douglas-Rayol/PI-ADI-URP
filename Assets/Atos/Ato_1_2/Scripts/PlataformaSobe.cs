using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.InteropServices;

public class PlataformaSobe : MonoBehaviour {    
    
    public float moveDistance = 5f; // Distância que a plataforma vai se mover
    public float moveDuration = 2f; // Duração do movimento em segundos
    public float pauseDuration = 1.5f; // Duração da pausa em segundos


    private void Start(){
            // Guarda a posição inicial da plataforma
        Vector3 initialPosition = transform.position;

        // Cria uma sequência de animação
        Sequence moveSequence = DOTween.Sequence();

        // Move a plataforma para a direita
        moveSequence.Append(transform.DOMoveY(initialPosition.y + moveDistance, moveDuration).SetEase(Ease.Linear));

        // Pausa por 1.5 segundos
        moveSequence.AppendInterval(pauseDuration);

        // Move a plataforma de volta para a posição inicial
        moveSequence.Append(transform.DOMoveY(initialPosition.y, moveDuration).SetEase(Ease.Linear));

        // Pausa por 1.5 segundos
        moveSequence.AppendInterval(pauseDuration);

        // Faz o movimento repetir indefinidamente
        moveSequence.SetLoops(-1, LoopType.Restart);

    }

     
        // Detecta quando o jogador entra na plataforma
        private void OnCollisionEnter(Collision collision){

            if (collision.gameObject.CompareTag("Player")){
                collision.transform.SetParent(transform);
            }
        }

        // Detecta quando o jogador sai da plataforma
        private void OnCollisionExit(Collision collision){

            if (collision.gameObject.CompareTag("Player")){
                collision.transform.SetParent(null);
            }
        }
}