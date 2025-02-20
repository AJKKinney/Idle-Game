using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AustenKinney.Essentials;

public class AchievementManager : Singleton<AchievementManager>
{
    [SerializeField] private List<Achievement> achievements = new List<Achievement>();

    private StatisticsData statistics = new StatisticsData();
    private IdleGameManager idleGameManager;


    #region Getters & Setters 

    public List<Achievement> Achievements { get => achievements; set => achievements = value; }
    public StatisticsData Statistics { get => statistics; set => statistics = value; }

    #endregion

    private void Start()
    {
        idleGameManager = IdleGameManager.Instance;

        Statistics.onTrackedClick += CheckUnskilledLaborAchievement;
        PopulateAchievementList();

    }

    private void PopulateAchievementList()
    {
        for (int i = 0; i < achievements.Count; i++)
        {
            idleGameManager.CurrentSaveData.Achievements.Add(new AchievementData(achievements[i].AchievementData));
        }
    }

    public void UnlockAchievement(string achievementName)
    {
        for (int i = 0; i < Achievements.Count; i++)
        {
            if (idleGameManager.CurrentSaveData.Achievements[i].AchievementName == achievementName)
            {
                if (idleGameManager.CurrentSaveData.Achievements[i].Unlocked == false)
                {
                    idleGameManager.CurrentSaveData.Achievements[i].UnlockAchievement();
                    idleGameManager.CurrentSaveData.IncreaseGlobalIncomeModifier(0.01f);
                }
            }
        }
    }

    #region Achievements

    private void CheckUnskilledLaborAchievement()
    {
        if(Statistics.TimesClickedCity >= 1)
        {
            UnlockAchievement("Unskilled Labor");
            Statistics.onTrackedClick -= CheckUnskilledLaborAchievement;
        }
    }

    #endregion
}
