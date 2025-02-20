using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EventNotificationsUIController : MonoBehaviour
{
    [SerializeField] private Image notificationsBackground;
    [SerializeField] private TextMeshProUGUI notificationsTextMesh;

    private EventManager eventManager;


    // Start is called before the first frame update
    void Start()
    {
        eventManager = EventManager.Instance;

        eventManager.onAddedEvent += UpdateUI;
    }

    private void UpdateUI()
    {
        if(eventManager.UnresolvedEvents.Count > 0)
        {
            notificationsBackground.enabled = true;
            notificationsTextMesh.enabled = true;

            if (eventManager.UnresolvedEvents.Count < 100)
            {
                notificationsTextMesh.text = eventManager.UnresolvedEvents.Count.ToString();
            }
            else
            {
                notificationsTextMesh.text = "100+";
            }
        }
        else
        {
            notificationsBackground.enabled = false;
            notificationsTextMesh.enabled = false;
        }
    }
}
