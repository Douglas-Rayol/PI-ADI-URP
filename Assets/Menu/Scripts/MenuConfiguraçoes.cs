using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuConfiguraçoes : MonoBehaviour
{
    public void SetFullscreen (bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
