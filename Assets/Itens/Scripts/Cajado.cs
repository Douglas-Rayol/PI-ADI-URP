using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajado : Item
{
    [SerializeField] GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();

        ParticulaStart.SetActive(true);
    }

    public override void DestroyItem()
    {
        StartCoroutine(DestroTime());
    }

    IEnumerator DestroTime()
    {
        Particula.SetActive(true);
        _gameManager.StartCoroutine(_gameManager.pausaTime());
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
