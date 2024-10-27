using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Splines;

public class SubirSerra : MonoBehaviour
{

    public float moveDistance = 5f; // Distância que a plataforma vai se mover
    public float moveDuration = 2f; // Duração do movimento em segundos
    public float pauseDuration = 1.5f; // Duração da pausa em segundos

    [SerializeField] BatalhaControle _batalhaControle;

    void Awake()
    {
        _batalhaControle = Camera.main.GetComponent<BatalhaControle>();
    }


    private void Start()
    {
        if(!_batalhaControle._pausaJogo)
        {
            Invoke("SobeSerra", 40f);
        }
        
    }


    private void SobeSerra()
    {
        if(!_batalhaControle._pausaJogo)
        {
            // Guarda a posição inicial da plataforma
            Vector3 initialPosition = transform.position;

            // Cria uma sequência de animação
            Sequence moveSequence = DOTween.Sequence();

            // Move a plataforma para cima
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
    }
}
