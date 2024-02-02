using UnityEngine;
using UnityEngine.Events;
public class TrapEvent : MonoBehaviour
{

    [SerializeField] private UnityEvent _OnEnter;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _OnEnter.Invoke();
        }

    }





}
