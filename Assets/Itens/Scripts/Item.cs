using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string _nome;
    [SerializeField] GameObject _paticula, _partculaStart;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void DestroyItem()
    {

    }

    public virtual string Nome
    {
      get { return _nome; }
        set { _nome = value; }
    }
    public virtual GameObject Particula
    {
        get { return _paticula; }
        set { _paticula = value; }
        
    }
    public virtual GameObject ParticulaStart
    {
        get { return _partculaStart; }
        set { _partculaStart = value; }

    }
}
