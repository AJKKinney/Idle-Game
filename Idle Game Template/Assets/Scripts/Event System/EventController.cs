using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float dragSpeed = 5f;
    [SerializeField] private float margin = 350f;

    private bool followMouse = false;

    private RectTransform rect;

    private EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        eventManager = EventManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

        if(followMouse == true)
        {
            rect.position = Vector3.Slerp(rect.position, Input.mousePosition, dragSpeed * Time.deltaTime);
        }
        else
        {
            rect.localPosition = Vector3.Slerp(rect.localPosition, Vector3.zero, dragSpeed * Time.deltaTime);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventManager.UnresolvedEvents.Count <= 0)
        {
            return;
        }

        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, null, out Vector2 localPoint);
        rect.pivot = new Vector2(localPoint.x/rect.sizeDelta.x + 0.5f, localPoint.y/rect.sizeDelta.y + 0.5f);
        rect.position = Input.mousePosition;
        followMouse = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventManager.UnresolvedEvents.Count <= 0)
        {
            return;
        }

        Vector2 offset = new Vector2(0.5f, 0.5f) - rect.pivot;
        offset *= new Vector2(rect.sizeDelta.x / 2, rect.sizeDelta.y / 2);
        rect.pivot = new Vector2(0.5f, 0.5f);

        if (rect.localPosition.x > margin)
        {
            SwipeRight();
            Debug.Log("Swiped Right on Event.");
        }
        else if(rect.localPosition.x < -margin)
        {
            SwipeLeft();
            Debug.Log("Swiped Left on Event.");
        }

        rect.localPosition += new Vector3(offset.x, offset.y);

        followMouse = false;
    }

    public void SwipeRight()
    {
        eventManager.UnresolvedEvents[0].SwipeRight();
        eventManager.UnresolvedEvents.RemoveAt(0);
    }

    public void SwipeLeft()
    {
        eventManager.UnresolvedEvents[0].SwipeLeft();
        eventManager.UnresolvedEvents.RemoveAt(0);
    }
}
