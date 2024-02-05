using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controladorsom : MonoBehaviour
{
    private bool estadoSom = true;
    [SerializeField] private AudioSource fundoMusical;

    [SerializeField] private Sprite somLigado;
    [SerializeField] private Sprite somDesligado;

    [SerializeField] private Sprite muteImage;

    public void LigarDesligarSom()
    {
        estadoSom = !estadoSom;
        fundoMusical.enabled = estadoSom;

        if (estadoSom)
        {
            muteImage = somLigado;
        }
        else
        {
            muteImage = somDesligado;
        }
    }

    public void VolumeMusical(float value)
    {
        //fundoMusical.volume = value;
    }
}
