using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceData
{
    [SerializeField] private ResourceType resourceType;
    [SerializeField] private float currentAmount;
    [SerializeField] private float currentBaseIncome;
    [SerializeField] private float incomeModifier;

    #region Getters & Setters

    public ResourceType ResourceType { get => resourceType; set => resourceType = value; }
    public float CurrentAmount { get => currentAmount; set => currentAmount = value; }
    public float CurrentBaseIncome { get => currentBaseIncome; set => currentBaseIncome = value; }
    public float IncomeModifier { get => incomeModifier; set => incomeModifier = value; }

    #endregion

    #region Constructors

    public ResourceData(ResourceType type, float amount, float income, float incomeModifer)
    {
        resourceType = type;
        currentAmount = amount;
        currentBaseIncome = income;
        this.IncomeModifier = incomeModifer;
    }

    #endregion
}

