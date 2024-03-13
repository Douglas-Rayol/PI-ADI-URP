using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string _nome;
    //[SerializeField] private int _tipo;
    [SerializeField] GameObject _paticula;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void DestroyItem()
    {

    }
    public virtual void ControItem()
    {

    }


    public virtual string Nome
    {
      get { return _nome; }
        set { _nome = value; }
    }
    /*public virtual int Tipo
    {
        get { return _tipo; }
        set { _tipo = value; }
    }*/
    public virtual GameObject Particula
    {
        get { return _paticula; }
        set { _paticula = value; }
    }
}
