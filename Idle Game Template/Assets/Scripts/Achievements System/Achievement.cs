using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement", order = 60)]
[System.Serializable]
public class Achievement : ScriptableObject
{
    [SerializeField] private AchievementData achievementData;

    #region Getters & Setters

    public AchievementData AchievementData { get => achievementData; set => achievementData = value; }

    #endregion
}
