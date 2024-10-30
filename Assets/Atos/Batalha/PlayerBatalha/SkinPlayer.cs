using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    [SerializeField] public GameObject _skinPadrao;
    [SerializeField] Renderer _renderer;
    [SerializeField] Color _corBlusa, _corShort;

    private void Update() {

        if(GetComponent<PlayerBatalha>()._tipo == 2)
        {
            Material[] materials = _renderer.materials;

            if(materials.Length >= 2)
            {
                Material specificMaterialBlusa = materials[1];
                specificMaterialBlusa.color = _corBlusa;
            }


        }
    }
    



}
