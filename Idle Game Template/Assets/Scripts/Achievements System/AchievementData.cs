using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementData
{
    [SerializeField] private string achievementName;
    [SerializeField] private string achievementFlavorText;
    [SerializeField] private string achievementCondition;
    [SerializeField] private Sprite achievementSprite;
    [SerializeField] private bool unlocked = false;

    #region Getters & Setters

    public string AchievementName { get => achievementName; set => achievementName = value; }
    public string AchievementFlavorText { get => achievementFlavorText; set => achievementFlavorText = value; }
    public string AchievementCondition { get => achievementCondition; set => achievementCondition = value; }
    public Sprite AchievementSprite { get => achievementSprite; set => achievementSprite = value; }
    public bool Unlocked { get => unlocked; set => unlocked = value; }

    #endregion

    #region Events & Delegates

    public delegate void OnAchievementUnlocked(AchievementData data);
    public static event OnAchievementUnlocked onAchievementUnlocked;

    #endregion

    public AchievementData(AchievementData data)
    {
        achievementName = data.achievementName;
        achievementFlavorText = data.achievementFlavorText;
        achievementCondition = data.achievementCondition;
        achievementSprite = data.achievementSprite;
        unlocked = data.unlocked;
    }

    public void UnlockAchievement()
    {
        Unlocked = true;

        if (onAchievementUnlocked != null)
        {
            onAchievementUnlocked.Invoke(this);
        }
    }
}
