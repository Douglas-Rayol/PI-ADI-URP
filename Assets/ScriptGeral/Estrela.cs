using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Estrela : MonoBehaviour
{
    [SerializeField] GameObject[] _estrelaVazia;
    [SerializeField] GameObject[] _estrela;
    GameControle _gameControle;
    // Start is called before the first frame update
    void Start()
    {
       
        _gameControle = Camera.main.GetComponent<GameControle>();
         StartCoroutine(VaziaEstrelas());
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator VaziaEstrelas()
    {
       for (int i = 0; i < _estrela.Length; i++)
        {
            _estrelaVazia[i].transform.localScale = Vector3.zero;
        }

        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < _estrela.Length; i++)
        {
            _estrelaVazia[i].transform.DOScale(4f, .25f);
            yield return new WaitForSeconds(0.25f);
            _estrelaVazia[i].transform.DOScale(2.5f, .25f);
        }
        yield return new WaitForSeconds(0.25f);
        PagEstrela();
    }

    public IEnumerator AtivaEstrela(int qtdEstrela)
    {
        for (int i = 0; i < qtdEstrela; i++)
        {
            _estrela[i].transform.localScale = Vector3.zero;
        }

        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < qtdEstrela; i++)
        {
            _estrela[i].transform.DOScale(5f, .25f);
            yield return new WaitForSeconds(0.25f);
            _estrela[i].transform.DOScale(2.5f, .25f);
        }
    }
    public void PagEstrela()
    {
        if(_gameControle._salvaScore <= 0)
        {
            StartCoroutine(AtivaEstrela(0));
        }
        else if(_gameControle._salvaScore <= 2)
        {
            StartCoroutine(AtivaEstrela(1));
        }
        else if(_gameControle._salvaScore <= 4)
        {
            StartCoroutine(AtivaEstrela(2));
        }
        else if(_gameControle._salvaScore >= 6)
        {
            StartCoroutine(AtivaEstrela(3));
        }
    }
}
