using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutomationButtonController : PurchaseButton
{
    [SerializeField] private List<ResourceType> resourceTypesForGeneration = new List<ResourceType>();
    [SerializeField] private List<float> resourceAmountGenerated = new List<float>();
    [SerializeField] private List<ResourceType> staticResourceTypesGiven = new List<ResourceType>();
    [SerializeField] private List<float> staticResourceAmountGiven = new List<float>();
    [SerializeField] private int numberOwned = 0;

    private bool owned = false;
    private float timer = 0;
    private TextMeshProUGUI titleTextMesh;

    public delegate void OnTimerUpdated(float progress);
    public event OnTimerUpdated onTimerUpdated;

    internal override void Start()
    {
        base.Start();
        onPurchase += UpgradeAutomation;

        titleTextMesh = GetComponentInChildren<TextMeshProUGUI>();
        titleTextMesh.text = purchaseName;
    }

    private void UpgradeAutomation()
    {
        for (int i = 0; i < staticResourceTypesGiven.Count; i++)
        {
            idleGameManager.GainResource(staticResourceTypesGiven[i], staticResourceAmountGiven[i]);
        }

        for (int i = 0; i < resourceTypesForGeneration.Count; i++)
        {
            idleGameManager.GainIncome(resourceTypesForGeneration[i], resourceAmountGenerated[i]);
        }

        numberOwned += 1;
    }

    internal override void Inspect()
    {
        string costsToDisplay = "";

        if (purchaseCosts.Count > 0)
        {
            costsToDisplay += "Costs:";

            for (int i = 0; i < purchaseCosts.Count; i++)
            {
                costsToDisplay += " " + purchaseCosts[i].ToString("0") + " " + resourceTypesForPurchase[i].ToString();
                if (i < purchaseCosts.Count - 1)
                {
                    costsToDisplay += ",";
                }
            }
        }

        List<string> statsToDisplay = new List<string>();

        for(int i = 0; i < resourceAmountGenerated.Count; i++)
        {
            statsToDisplay.Add("Each " + purchaseName + " generates " + resourceAmountGenerated[i].ToString() + " " + resourceTypesForGeneration[i].ToString() + " per second.");
        }

        for (int i = 0; i < staticResourceAmountGiven.Count; i++)
        {
            statsToDisplay.Add("Each " + purchaseName + " provides " + staticResourceAmountGiven[i].ToString() + " " + staticResourceTypesGiven[i].ToString() + ".");
        }

        if (numberOwned > 0)
        {
            for (int i = 0; i < resourceAmountGenerated.Count; i++)
            {
                statsToDisplay.Add("Currently generating " + (resourceAmountGenerated[i] * numberOwned).ToString() + " " + resourceTypesForGeneration[i].ToString() + " per second.");
            }
        }

        inspectionManager.InspectElement(purchaseName, costsToDisplay, purchaseDescription, null, statsToDisplay, rect);
    }

    #region Deprecated

    /*
     *
    [SerializeField] private float automationSpeed = 3f;


    private void Update()
    {
        if(numberOwned > 0)
        {
            if (timer >= automationSpeed)
            {
                for (int i = 0; i < resourceTypesForGeneration.Count; i++)
                {
                    idleGameManager.GainResource(resourceTypesForGeneration[i], resourceAmountGiven[i] * numberOwned);
                }

                timer -= automationSpeed;
            }
            else
            {
                timer += Time.deltaTime;
            }

            onTimerUpdated.Invoke(timer / automationSpeed);
        }
    }

    *
    */

    #endregion
}
