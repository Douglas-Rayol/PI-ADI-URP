using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class VibrationController : MonoBehaviour
{
    public void Vibrar(float _intencidadeMin, float _intencidadeMax)
    {       

        if (Gamepad.current != null)
        {
            // Configura a vibração dos motores de baixa e alta frequência
            Gamepad.current.SetMotorSpeeds(_intencidadeMin, _intencidadeMax);

            Invoke("PararVibracao", .1f);

        }
    }

    public void VibrarAnim()
    {

        if (Gamepad.current != null)
        {
            // Configura a vibração dos motores de baixa e alta frequência
            Gamepad.current.SetMotorSpeeds(1f, 5f);

            Invoke("PararVibracao", .1f);

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
