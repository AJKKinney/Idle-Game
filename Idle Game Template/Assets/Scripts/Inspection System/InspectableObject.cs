using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InspectableObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    internal InspectionManager inspectionManager;
    internal RectTransform rect;

    // Start is called before the first frame update
    internal virtual void Start()
    {
        inspectionManager = InspectionManager.Instance;
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Inspect();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EndInspect();
    }

    internal virtual void Inspect()
    {

    }

    internal virtual void EndInspect()
    {
        inspectionManager.CloseInspectionPanel();
    }
}
