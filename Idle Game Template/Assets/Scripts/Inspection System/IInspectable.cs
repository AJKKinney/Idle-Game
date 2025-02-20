using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInspectable
{
    void Inspect(string inspectableName, string inspectableDescription, List<string> inspectableStats);
}
