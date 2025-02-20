using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyDisplayTextController : InspectableObject
{
    [SerializeField] private ResourceType resourceTypeForDisplay;

    private TextMeshProUGUI displayText;
    private IdleGameManager idleGameManager;

    // Start is called before the first frame update
    internal override void Start()
    {
        base.Start();

        displayText = GetComponent<TextMeshProUGUI>();
        idleGameManager = IdleGameManager.Instance;
        idleGameManager.onCurrencyChanged += UpdateDisplayText;
    }

    private void UpdateDisplayText(ResourceType type)
    {
        if (type == resourceTypeForDisplay)
        {
            for (int i = 0; i < idleGameManager.CurrentSaveData.Resources.Count; i++)
            {
                if (idleGameManager.CurrentSaveData.Resources[i].ResourceType == type)
                {
                    displayText.text = Mathf.FloorToInt(idleGameManager.CurrentSaveData.Resources[i].CurrentAmount).ToString();
                }
            }
        }
    }

    internal override void Inspect()
    {
        string incomeDisplay = "";

        List<string> incomeStats = new List<string>();


        for (int i = 0; i < idleGameManager.CurrentSaveData.Resources.Count; i++)
        {
            if (idleGameManager.CurrentSaveData.Resources[i].ResourceType == resourceTypeForDisplay)
            {
                if (idleGameManager.CurrentSaveData.Resources[i].CurrentBaseIncome > 0)
                {
                    incomeDisplay = "Currently generating " + (idleGameManager.CurrentSaveData.Resources[i].CurrentBaseIncome * idleGameManager.CurrentSaveData.GlobalIncomeModifier * idleGameManager.CurrentSaveData.Resources[i].IncomeModifier).ToString("0.###") + " per second.";

                    if (idleGameManager.CurrentSaveData.Resources[i].IncomeModifier > 1 || idleGameManager.CurrentSaveData.GlobalIncomeModifier > 0)
                    {
                        incomeStats.Add("Base Income: " + idleGameManager.CurrentSaveData.Resources[i].CurrentBaseIncome);

                        if (idleGameManager.CurrentSaveData.Resources[i].IncomeModifier > 1)
                        {
                            incomeStats.Add(resourceTypeForDisplay.ToString() + " Income Modifier: +" + ((idleGameManager.CurrentSaveData.Resources[i].IncomeModifier - 1) * 100).ToString("0") + "%");
                        }

                        if (idleGameManager.CurrentSaveData.GlobalIncomeModifier > 0)
                        {
                            incomeStats.Add("Global Income Modifier: +" + ((idleGameManager.CurrentSaveData.GlobalIncomeModifier - 1) * 100).ToString("0") + "%");
                        }
                    }
                }
            }
        }



        inspectionManager.InspectElement(resourceTypeForDisplay.ToString(), displayText.text, incomeDisplay , null, incomeStats, rect);
    }
}
