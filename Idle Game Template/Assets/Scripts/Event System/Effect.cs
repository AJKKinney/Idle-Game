using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{
    [SerializeField] EffectType effectType;

    [SerializeField] ResourceType resourceType;
    [SerializeField] float amount;

    [SerializeField] DialogueData dialogue;

    public void ResolveEffect()
    {
        switch(effectType)
        {
            case EffectType.AdjustResource:
                IdleGameManager.Instance.GainResource(resourceType, amount);
                break;
            case EffectType.AdjustIncome:
                IdleGameManager.Instance.GainIncome(resourceType, amount);
                break;
            case EffectType.AdjustIncomeMod:
                IdleGameManager.Instance.CurrentSaveData.IncreaseGlobalIncomeModifier(amount);
                break;

            case EffectType.StartDialogue:
                DialogueManager.Instance.StartDialogue(dialogue);
                break;
        }
    }
}
