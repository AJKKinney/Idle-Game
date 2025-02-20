using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private List<ResourceData> resources = new List<ResourceData>
    {
        new ResourceData(ResourceType.Gold, 0f, 0f, 1f),
        new ResourceData(ResourceType.Influence, 0f, 0f, 1f),
        new ResourceData(ResourceType.Follower, 0f, 0f, 1f),
        new ResourceData(ResourceType.Might, 0f, 0f, 1f),
        new ResourceData(ResourceType.Housing, 0f, 0f, 1f)
    };

    private float globalIncomeModifier = 1f;
    private List<AchievementData> achievements = new List<AchievementData>();


    #region Getters & Setters

    public List<ResourceData> Resources { get => resources; set => resources = value; }
    public float GlobalIncomeModifier { get => globalIncomeModifier; set => globalIncomeModifier = value; }
    public List<AchievementData> Achievements { get => achievements; set => achievements = value; }

    #endregion

    #region Events & Delegates

    public delegate void OnGlobalIncomeModifierChanged();
    public static OnGlobalIncomeModifierChanged onGlobalIncomeModifierChanged;

    #endregion

    public void AddResource(ResourceType type, float amount)
    {
        for(int i = 0; i < Resources.Count; i++)
        {
            if(Resources[i].ResourceType == type)
            {
                Resources[i].CurrentAmount += amount;
            }
        }
    }

    public void AddResourceIncome(ResourceType type, float amount)
    {
        for(int i = 0; i < Resources.Count; i++)
        {
            if (Resources[i].ResourceType == type)
            {
                Resources[i].CurrentBaseIncome += amount;
            }
        }
    }

    public bool TryRemoveResource(ResourceType type, float amount)
    {
        for (int i = 0; i < Resources.Count; i++)
        {
            if (Resources[i].ResourceType == type)
            {
                if (Resources[i].CurrentAmount >= amount)
                {
                    Resources[i].CurrentAmount -= amount;
                    return true;
                }
            }
        }

        return false;
    }

    public void IncreaseGlobalIncomeModifier(float amount)
    {
        globalIncomeModifier += amount;

        if (onGlobalIncomeModifierChanged != null)
        {
            onGlobalIncomeModifierChanged.Invoke();
        }
    }
}
