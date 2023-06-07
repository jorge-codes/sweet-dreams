using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TimerEvent[] events;
    private List<TimerEvent> eventList;

    void Start()
    {
        eventList = new List<TimerEvent>(events).OrderBy(e => e.time).ToList();
    }

    void Update()
    {
        RunEvents();
    }

    private void RunEvents()
    {
        foreach (var e in events.Where(e => !e.triggered))
        {
            if (e.time > Time.timeSinceLevelLoad) return;
            
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
