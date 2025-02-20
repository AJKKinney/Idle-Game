using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceIncomeDisplayController : MonoBehaviour
{
    [SerializeField] private ResourceType resourceTypeForDisplay;

    private TextMeshProUGUI displayText;
    private IdleGameManager idleGameManager;

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<TextMeshProUGUI>();
        idleGameManager = IdleGameManager.Instance;
        idleGameManager.onIncomeChanged += UpdateText;
    }


    private void UpdateText(ResourceType type)
    {
        if (type == resourceTypeForDisplay)
        {
            for (int i = 0; i < idleGameManager.CurrentSaveData.Resources.Count; i++)
            {
                if (idleGameManager.CurrentSaveData.Resources[i].ResourceType == type)
                {
                    displayText.text = (idleGameManager.CurrentSaveData.Resources[i].CurrentBaseIncome * idleGameManager.CurrentSaveData.GlobalIncomeModifier * idleGameManager.CurrentSaveData.Resources[i].IncomeModifier).ToString("0.###") + "/ per second";
                }
            }
        }
    }
}
