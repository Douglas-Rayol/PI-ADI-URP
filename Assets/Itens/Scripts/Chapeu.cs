using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapeu : Item
{
    [SerializeField] GameManager _pausaJogo;

    private void Start()
    {
        _pausaJogo = FindAnyObjectByType<GameManager>();
    }

    public override void DestroyItem()
    {
        StartCoroutine(DestroTime());
    }

    IEnumerator DestroTime()
    {
        Particula.SetActive(true);
        _pausaJogo.StartCoroutine(_pausaJogo.pausaTime());
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }
}
