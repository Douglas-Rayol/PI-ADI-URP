using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoystick : Joystick
{
    [SerializeField] public bool _verificaJoystick;
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1;

    [SerializeField] Vector2 _salvaPos;

    protected override void Start()
    {
        _salvaPos = background.anchoredPosition;

        MoveThreshold = moveThreshold;
        base.Start();
        background.gameObject.SetActive(true);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = _salvaPos;
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);


    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.anchoredPosition = _salvaPos;
        background.gameObject.SetActive(true);
        base.OnPointerUp(eventData);
        
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {

        if (magnitude > moveThreshold)
        {
            _verificaJoystick = true;
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            background.anchoredPosition += difference;
            
        }

        base.HandleInput(magnitude, normalised, radius, cam);
    }
}