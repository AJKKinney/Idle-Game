using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerUpgradeButtonController : PurchaseButton
{
    [SerializeField] private List<ResourceType> resourceTypesForGeneration = new List<ResourceType>();
    [SerializeField] private List<float> amountIncreased = new List<float>();
    [SerializeField] private ClickerButtonController clickerButtonController;


    internal override void Start()
    {
        base.Start();
        onPurchase += UpgradeClicker;
    }

    private void UpgradeClicker()
    {
        for (int z = 0; z < resourceTypesForGeneration.Count; z++)
        {
            bool hasResourceProduction = false;

            for (int i = 0; i < clickerButtonController.ResourceTypesGenerated.Count; i++)
            {
                if (clickerButtonController.ResourceTypesGenerated[i] == resourceTypesForGeneration[z])
                {
                    clickerButtonController.ResourceAmountsGenerated[i] += amountIncreased[z];
                    hasResourceProduction = true;
                }
            }

            if(hasResourceProduction == false)
            {
                clickerButtonController.ResourceTypesGenerated.Add(resourceTypesForGeneration[z]);
                clickerButtonController.ResourceAmountsGenerated.Add(amountIncreased[z]);
            }
        }
    }
}
