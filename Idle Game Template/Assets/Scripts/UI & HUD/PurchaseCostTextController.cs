using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PurchaseCostTextController : MonoBehaviour
{
    private PurchaseButton purchaseButton;
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        purchaseButton = GetComponentInParent<PurchaseButton>();
        purchaseButton.onCostChanged += UpdateText;

        UpdateText(purchaseButton.purchaseCosts[0]);
    }

    private void UpdateText(float currentCost)
    {
        textMesh.text = Mathf.RoundToInt(currentCost).ToString();
    }
}
