using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Event", menuName = "Event", order = 62)]
public class EventData : ScriptableObject
{
    [SerializeField] private string eventName;
    [SerializeField] private string eventDescription;
    [SerializeField] private Sprite eventImage;

    [Header("Swipe Right")]
    [SerializeField] private string rightInteractionDescription;
    [SerializeField] private List<Effect> rightInteractionEffects = new List<Effect>();

    [Header("Swipe Left")]
    [SerializeField] private string leftInteractionDescription;
    [SerializeField] private List<Effect> leftInteractionEffects = new List<Effect>();

    #region Getters & Setters

    public string EventName { get => eventName; set => eventName = value; }
    public string EventDescription { get => eventDescription; set => eventDescription = value; }
    public Sprite EventImage { get => eventImage; set => eventImage = value; }
    public string RightInteractionDescription { get => rightInteractionDescription; set => rightInteractionDescription = value; }
    public string LeftInteractionDescription { get => leftInteractionDescription; set => leftInteractionDescription = value; }

    #endregion

    public virtual void SwipeRight()
    {
        //effects may be increase or decrease resources, increase or decrease income, increase or decrease income modifier, start dialogue, unlock location, unlock upgrade, unlock achievement, recieve item

        for(int i = 0; i < rightInteractionEffects.Count; i++)
        {
            rightInteractionEffects[i].ResolveEffect();
        }
    }

    public virtual void SwipeLeft()
    {
        for(int i = 0; i < leftInteractionEffects.Count; i++)
        {
            leftInteractionEffects[i].ResolveEffect();
        }
    }
}
