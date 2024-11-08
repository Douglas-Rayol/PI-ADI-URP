using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCajado : MonoBehaviour
{
    [SerializeField] Transform _posSpawn;
    [SerializeField] GameObject _prefabCajado;

    void Start()
    {
        InvokeRepeating(nameof(SpawnaCajadinho), 30, 60);
    }



    private void SpawnaCajadinho()
    {
        Instantiate(_prefabCajado, _posSpawn, false);
    }
}
