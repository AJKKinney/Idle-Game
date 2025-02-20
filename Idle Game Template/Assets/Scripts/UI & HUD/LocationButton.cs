using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationButton : InspectableObject
{
    [SerializeField] private string locationName;
    [SerializeField] private string locationDescription;

    internal override void Inspect()
    {
        base.Inspect();

        inspectionManager.InspectElement(locationName, "", locationDescription, null, new List<string>(), rect);
    }
}
