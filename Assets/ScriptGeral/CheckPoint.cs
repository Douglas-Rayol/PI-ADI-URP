using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    CheckPoint _manager;
    [SerializeField] int _fase;
    [SerializeField] int _partfase;
    [SerializeField] int _life;
    [SerializeField] Transform _posPlayer;
    [SerializeField] Transform[] _pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Aumentarfase()
    {
        _fase++;
    }

    public void CkeckPointSalvar(Vector3 pos)
    {
        PlayerPrefs.SetFloat("posX", pos.x);
        PlayerPrefs.SetFloat("posY", pos.y);
        PlayerPrefs.SetFloat("posZ", pos.z);
    }

    public void Salvar()
    {
        PlayerPrefs.SetInt("fase", _fase);
        PlayerPrefs.SetInt("_partfase", _partfase);
    }

    public void Carregar()
    {
        _fase = PlayerPrefs.GetInt("fase");
        _partfase = PlayerPrefs.GetInt("_partfase");
        // _posPlayer.transform.localPosition = _pos[_partfase].transform.position;

    }
}
