using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlePag : MonoBehaviour
{
    public int _totalPag;
    public Text _pagText;
    public static ControlePag _instance;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    public void UpdatePagText()
    {
        _pagText.text = _totalPag.ToString();
    }
}
