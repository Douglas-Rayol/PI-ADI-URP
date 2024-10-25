using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnDePowerUps : MonoBehaviour
{
    [SerializeField] Transform[] _transform;
    [SerializeField] GameObject[] _powerUps;

    [SerializeField] int _tempoSpawn;


    private void Start()
    {
        StartCoroutine(InvocaPowerUp());
    }

    IEnumerator InvocaPowerUp()
    {
        yield return new WaitForSeconds(_tempoSpawn);

        Shuffle(_transform);
        Shuffle(_powerUps);

        Instantiate(_powerUps[0], _transform[0].position, Quaternion.identity);

        yield return InvocaPowerUp();

    }

    void Shuffle(Transform[] _posicao)
    {
        for (int j = _posicao.Length - 1; j > 0; j--)
        {
            int rnd = UnityEngine.Random.Range(0, j + 1);
            Transform temp = _posicao[j];
            _posicao[j] = _posicao[rnd];
            _posicao[rnd] = temp;
        }
    }

    void Shuffle(GameObject[] _objeto)
    {
        for (int j = _objeto.Length - 1; j > 0; j--)
        {
            int rnd = UnityEngine.Random.Range(0, j + 1);
            GameObject temp = _objeto[j];
            _objeto[j] = _objeto[rnd];
            _objeto[rnd] = temp;
        }
    }

}
