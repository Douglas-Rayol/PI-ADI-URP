using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeWriterr : MonoBehaviour
{
    [SerializeField] ColetaConf _coletaConf;
    public Text _textWriter;
    public float _delayWriter = 0.01f;
    public string _escrevaFrase;
    public string _escrevaFrase2;

    // Start is called before the first frame update
    void Start()
    {
        if(_coletaConf._totalPag < 12)
        {
            StartCoroutine("MostrarTexto", _escrevaFrase2);
        }
        else
        {
            StartCoroutine("MostrarTexto", _escrevaFrase);
        }
        
    }

    IEnumerator MostrarTexto(string textType)
    {
        _textWriter.text = " ";
        for (int letter = 0; letter < textType.Length; letter++)
        {
            _textWriter.text = _textWriter.text + textType[letter];
            yield return new WaitForSeconds(_delayWriter);
        }
       

    }
    
}

