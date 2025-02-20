using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : InspectableObject
{
    [SerializeField] private string buttonName;

    internal override void Inspect()
    {
        base.Inspect();
        inspectionManager.InspectElement(buttonName, "", "", null, new List<string>(), rect);
    }
}
