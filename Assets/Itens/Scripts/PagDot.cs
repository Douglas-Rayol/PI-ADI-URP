using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PagDot : MonoBehaviour
{
    [SerializeField] GameObject _hudPag;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PagAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PagAnim()
    {
        _hudPag.transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(.25f);
        _hudPag.transform.DOScale(2f, .25f);
        yield return new WaitForSeconds(.25f);
        _hudPag.transform.DOScale(1.4f, .25f);
    }
}
