using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SubirSerra : MonoBehaviour{


    public Transform _spline; 
    public float _moveDistance; // A distância que a spline vai se mover
    public float _duracao; // Duração do movimento
    public float _espera; // Tempo de espera antes do movimento

    void Start()
    {
        //  move a spline após um atraso
        DOVirtual.DelayedCall(_espera, MoveSplineUp);
    }

    void MoveSplineUp()
    {
        // Calcula a nova posição
        Vector3 targetPosition = _spline.position + new Vector3(0, _moveDistance, 0);

        // Move a spline usando
        _spline.DOMove(targetPosition, _duracao).SetEase(Ease.OutQuad);
    }

}
