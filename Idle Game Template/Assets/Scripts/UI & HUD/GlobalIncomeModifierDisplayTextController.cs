using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GlobalIncomeModifierDisplayTextController : MonoBehaviour
{
    private IdleGameManager idleGameManager;

    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        idleGameManager = IdleGameManager.Instance;

        textMesh = GetComponent<TextMeshProUGUI>();

        SaveData.onGlobalIncomeModifierChanged += UpdateText;

        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateText()
    {
        textMesh.text = "Income Modifier From Achievemenets: " + ((idleGameManager.CurrentSaveData.GlobalIncomeModifier - 1f) * 100).ToString("0") + "%";
    }
}
