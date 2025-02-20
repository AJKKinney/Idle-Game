using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AustenKinney.Essentials;

public class EventManager : Singleton<EventManager>
{
    private List<EventData> unresolvedEvents = new List<EventData>();

    [SerializeField] List<EventData> events = new List<EventData>();

    #region Getters & Setters

    public List<EventData> UnresolvedEvents { get => unresolvedEvents; set => unresolvedEvents = value; }

    #endregion

    #region Events & Delegates

    public delegate void OnAddedEvent();
    public event OnAddedEvent onAddedEvent;

    public delegate void OnFinishedEvent();
    public event OnFinishedEvent onFinishedEvent;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        CheckGameStartEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEvent(string eventName)
    {
        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].EventName == eventName)
            {
                EventData data = events[i];

                UnresolvedEvents.Add(data);

                if (onAddedEvent != null)
                {
                    onAddedEvent.Invoke();
                }
            }
        }
    }

    #region Events

    private void CheckGameStartEvent()
    {
        AddEvent("Start");
    }

    #endregion
}
