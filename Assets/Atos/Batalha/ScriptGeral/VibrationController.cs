using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class VibrationController : MonoBehaviour
{
    public void Vibrar(float intensidadeBaixa, float intensidadeAlta)
    {
        if (Gamepad.current != null)
        {
            // Configura a vibração dos motores de baixa e alta frequência
            Gamepad.current.SetMotorSpeeds(intensidadeBaixa, intensidadeAlta);

            Invoke("PararVibracao", 1f);
        }
    }

    public void PararVibracao()
    {
        if (Gamepad.current != null)
        {
            // Para a vibração
            Gamepad.current.SetMotorSpeeds(0f, 0f);
        }
    }
}
