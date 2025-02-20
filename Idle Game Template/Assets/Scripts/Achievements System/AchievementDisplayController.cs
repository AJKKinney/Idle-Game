using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementDisplayController : InspectableObject
{
    [SerializeField] private AchievementData achievementData;

    private Image achievementDisplayImage;

    #region Getters & Setters

    public Image AchievementDisplayImage 
    { 
        get 
        {
            if (achievementDisplayImage != null)
            {
                return achievementDisplayImage;
            }
            else
            {
                achievementDisplayImage = GetComponent<Image>();
                return achievementDisplayImage;
            }
        } 
        set => achievementDisplayImage = value; 
    }

    #endregion

    internal override void Start()
    {
        base.Start();

        AchievementDisplayImage = GetComponent<Image>();

        AchievementData.onAchievementUnlocked += UnlockAchievement;
    }

    public void Setup(AchievementData achievement)
    {
        achievementData = achievement;

        if(achievementData.Unlocked == true)
        {
            UnlockAchievement(achievement);
        }
    }

    private void UnlockAchievement(AchievementData achievement)
    {
        if (achievement.AchievementName == achievementData.AchievementName)
        {
            achievementData.Unlocked = true;

            AchievementDisplayImage.sprite = achievementData.AchievementSprite;
        }
    }

    internal override void Inspect()
    {
        inspectionManager.InspectElement(achievementData.AchievementName, achievementData.AchievementCondition, achievementData.AchievementFlavorText, achievementData.AchievementSprite, new List<string>(), rect);
    }
}
