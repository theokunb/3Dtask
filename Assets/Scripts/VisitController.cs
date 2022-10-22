using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisitController : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _exited;

    private void Start() 
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _entered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _exited?.Invoke();
        }
    }
}
