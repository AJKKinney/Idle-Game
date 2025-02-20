using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : InspectableObject
{
    [SerializeField] internal string purchaseName;
    [SerializeField] internal string purchaseDescription;
    [SerializeField] internal List<ResourceType> resourceTypesForPurchase = new List<ResourceType>();
    [SerializeField] internal List<float> purchaseCosts = new List<float>();
    [SerializeField] internal List<float> purchaseCostMultipliers = new List<float>();

    internal IdleGameManager idleGameManager;
    internal Button button;

    #region Events & Delegates

    internal delegate void OnPurchase();
    internal event OnPurchase onPurchase;

    internal delegate void OnCostChanged(float currentUpgradeCost);
    internal event OnCostChanged onCostChanged;

    #endregion

    internal override void Start()
    {
        base.Start();

        idleGameManager = IdleGameManager.Instance;
        button = GetComponent<Button>();
        
        button.onClick.AddListener(Purchase);
    }

    internal void Purchase()
    {
        for (int i = 0; i < resourceTypesForPurchase.Count; i++)
        {
            for(int r = 0; r < idleGameManager.CurrentSaveData.Resources.Count; r++)
            {
                if(resourceTypesForPurchase[i] == idleGameManager.CurrentSaveData.Resources[r].ResourceType)
                {
                    if (Mathf.RoundToInt(purchaseCosts[i]) > idleGameManager.CurrentSaveData.Resources[r].CurrentAmount)
                    {
                        //return on not having enough of any required resources
                        return;
                    }
                    else
                    {
                        //else return out to check on next required resource
                        break;
                    }
                }
            }
        }

        for (int i = 0; i < resourceTypesForPurchase.Count; i++)
        {
            if (idleGameManager.TrySpendResource(resourceTypesForPurchase[i], Mathf.RoundToInt(purchaseCosts[i])))
            {
                if (purchaseCostMultipliers.Count > i)
                {
                    purchaseCosts[i] = purchaseCosts[i] * purchaseCostMultipliers[i];

                    if (onCostChanged != null)
                    {
                        onCostChanged.Invoke(purchaseCosts[i]);
                    }
                }

                if (onPurchase != null)
                {
                    onPurchase.Invoke();
                }
            }
        }

        if (gameObject.activeSelf == true)
        {
            Inspect();
        }
        else
        {
            EndInspect();
        }
    }

    internal override void Inspect()
    {
        base.Inspect();

        string costsToDisplay = "";

        if (purchaseCosts.Count > 0)
        {
            costsToDisplay += "Costs:";

            for (int i = 0; i < purchaseCosts.Count; i++)
            {
                costsToDisplay += " " + purchaseCosts[i].ToString() + " " + resourceTypesForPurchase[i].ToString();
                if(i < purchaseCosts.Count - 1)
                {
                    costsToDisplay += ",";
                }
            }
        }

        inspectionManager.InspectElement(purchaseName, costsToDisplay, purchaseDescription, null, new List<string>(), rect);
    }
}
