using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapeu : Item
{
    public override void DestroyItem()
    {
        StartCoroutine(DestroTime());
    }

    IEnumerator DestroTime ()
    {
        Particula.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }
}
