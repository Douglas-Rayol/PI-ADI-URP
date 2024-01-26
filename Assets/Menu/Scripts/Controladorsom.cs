using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controladorsom : MonoBehaviour
{
    private bool estadoSom = true;
    [SerializeField] private AudioSource fundoMusical;

    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;

    [SerializeField] private Sprite muteImage;

    public void LigarDesligarSom()
    {
        estadoSom = !estadoSom;
        fundoMusical.enabled = estadoSom;

        if (estadoSom)
        {
            muteImage = somLigadoSprite;
        }
        else
        {
            muteImage = somDesligadoSprite;
        }
    }

    public void VolumeMusical(float value)
    {
        //fundoMusical.volume = value;
    }
}
