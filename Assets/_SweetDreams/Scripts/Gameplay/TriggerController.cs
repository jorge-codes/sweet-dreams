using UnityEngine;
using UnityEngine.Events;

public class TriggerController : MonoBehaviour
{
    public UnityEvent onTriggerEnterEvents;
    public UnityEvent onTriggerExitEvents;

    private void OnTriggerEnter2D(Collider2D col)
    {
        onTriggerEnterEvents.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExitEvents.Invoke();
    }
}
