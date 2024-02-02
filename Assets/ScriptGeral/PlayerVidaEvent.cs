using UnityEngine;
using UnityEngine.Events;

public class PlayerVidaEvent : MonoBehaviour
{

    [SerializeField] private UnityEvent _OnDano;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Inimigo1"))
        {
            _OnDano.Invoke();
        }
    }
}
