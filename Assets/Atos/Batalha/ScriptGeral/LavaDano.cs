using System.Collections;
using UnityEngine;

public class LavaDano : MonoBehaviour
{
    [SerializeField] bool _colidindo;
    [SerializeField] BatalhaControle _batalhaControle;
    private Coroutine danoCoroutine;

    void Awake()
    {
        _batalhaControle = Camera.main.GetComponent<BatalhaControle>();
    }

    void Update()
    {
        // Verifica constantemente se o jogo está pausado
        if (!_batalhaControle._pausaJogo && _colidindo && danoCoroutine == null)
        {
            danoCoroutine = StartCoroutine(ChamaDano());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            _colidindo = true;

            if (!_batalhaControle._pausaJogo && danoCoroutine == null)
            {
                danoCoroutine = StartCoroutine(ChamaDano());
            }
        }
    }

    IEnumerator ChamaDano()
    {
        while (_colidindo && !_batalhaControle._pausaJogo)
        {
            yield return new WaitForSeconds(0.5f);
            GetComponent<PlayerBatalha>()._vidaMin -= 1;
            GetComponent<PlayerBatalha>()._anim.SetTrigger("Hit");
        }
        
        danoCoroutine = null;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            _colidindo = false;

            // Para a coroutine de dano quando o jogador sai da colisão
            if (danoCoroutine != null)
            {
                StopCoroutine(danoCoroutine);
                danoCoroutine = null;
            }
        }
    }
}
