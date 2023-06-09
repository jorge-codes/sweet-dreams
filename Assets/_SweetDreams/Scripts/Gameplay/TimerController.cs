using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TimerEvent[] events;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        RunEvents(timer);
    }

    private void RunEvents(float timeElapsed)
    {
        var pendingEvents = events.Where(e => !e.triggered);
        gameObject.SetActive(pendingEvents.Any());

        foreach (var e in pendingEvents)
        {
            if (e.time > timeElapsed) return;
            
            e.events.Invoke();
            e.triggered = true;
        }
        
    }
}

[System.Serializable]
public class TimerEvent
{
    [ReadOnly] public bool triggered;
    public float time;
    public UnityEvent events;
}
