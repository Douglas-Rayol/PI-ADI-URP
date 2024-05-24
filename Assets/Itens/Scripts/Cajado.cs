using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajado : Item
{
    [SerializeField] GameManager _pausaJogo;

    private void Start()
    {
        _pausaJogo = FindAnyObjectByType<GameManager>();
        ParticulaStart.SetActive(true);
    }

    public override void DestroyItem()
    {
        StartCoroutine(DestroTime());
    }

    IEnumerator DestroTime()
    {
        Particula.SetActive(true);
        _pausaJogo.StartCoroutine(_pausaJogo.pausaTime());
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
