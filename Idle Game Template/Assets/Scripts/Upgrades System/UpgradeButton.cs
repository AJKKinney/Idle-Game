using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeButton : PurchaseButton
{
    public UnityEvent OnUpgrade;

    // Update is called once per frame
    void Update()
    {
        onPurchase += FireOnUpgrade;
    }

    private void FireOnUpgrade()
    {
        OnUpgrade.Invoke();
        button.interactable = false;
        gameObject.SetActive(false);
    }
}
