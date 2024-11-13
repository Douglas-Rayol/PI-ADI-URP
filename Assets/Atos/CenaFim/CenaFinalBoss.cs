using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaFinalBoss : MonoBehaviour
{

    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _hpGalo;

    void Awake()
    {
        _gameManager = GetComponent<GameManager>();
    }


    void Update()
    {
        if(_gameManager._pause)
        {
            _hpGalo.SetActive(false);
        }
        else
        {
            _hpGalo.SetActive(true);
        }
    }

    public void CenaFinal()
    {
        SceneManager.LoadScene("CenaFim");
    }
}
