using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AustenKinney.Essentials;

public class IdleGameManager : Singleton<IdleGameManager>
{
    [SerializeField] private SaveData currentSaveData = new SaveData();

    #region Events & Delegates

    public delegate void OnCurrencyChanged(ResourceType type);
    public event OnCurrencyChanged onCurrencyChanged;

    public delegate void OnIncomeChanged(ResourceType type);
    public event OnIncomeChanged onIncomeChanged;

    #endregion

    #region Getters & Setters

    public SaveData CurrentSaveData { get => currentSaveData; set => currentSaveData = value; }

    #endregion

    #region Game Functions


    private void Update()
    {
        for (int i = 0; i < CurrentSaveData.Resources.Count; i++)
        {
            GainResource(currentSaveData.Resources[i].ResourceType, currentSaveData.Resources[i].CurrentBaseIncome * currentSaveData.GlobalIncomeModifier * currentSaveData.Resources[i].IncomeModifier * Time.deltaTime);
        }
    }

    public void GainResource(ResourceType type, float amount)
    {
        currentSaveData.AddResource(type, amount);

        if (onCurrencyChanged != null)
        {
            onCurrencyChanged.Invoke(type);
        }
    }

    public void GainIncome(ResourceType type, float amount)
    {
        currentSaveData.AddResourceIncome(type, amount);

        if(onIncomeChanged != null)
        {
            onIncomeChanged.Invoke(type);
        }
    }

    public bool TrySpendResource(ResourceType type, float amountSpent)
    {
        bool resourceRemoved = currentSaveData.TryRemoveResource(type, amountSpent);

        if (onCurrencyChanged != null)
        {
            onCurrencyChanged.Invoke(type);
        }

        return resourceRemoved;
    }


    #endregion
}
