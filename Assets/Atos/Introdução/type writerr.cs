using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeWriterr : MonoBehaviour
{
    public Text _textWriter;
    public float _delayWriter = 0.01f;
    public string _escrevaFrase;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MostrarTexto", _escrevaFrase);
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

