using System.Collections;
using DG.Tweening;
using UnityEngine;



public class QuedaPlataforma : MonoBehaviour
{

    [SerializeField] Rigidbody _rb;

    Vector3 _posicao;
    Vector3 _scale;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _posicao = transform.position;
        _scale = transform.localScale;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Reseta());
        }
    }

    IEnumerator Reseta()
    {
        yield return new WaitForSeconds(0.15f);
        _rb.DOMoveY(_rb.transform.position.y - 50, 3f, false);
        yield return new WaitForSeconds(3f);
        transform.DOScale(0, .3f);
        _rb.DOMove(_posicao, 1f, false);
        yield return new WaitForSeconds(2f);
        transform.DOScale(_scale, .3f);

    }
}
