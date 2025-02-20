using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementPanelController : MonoBehaviour
{ 
    [SerializeField] private GameObject AchievementDisplayPrefab;
    [SerializeField] private GameObject AchievementDisplayParent;

    private IdleGameManager idleGameManager;

    private void Start()
    {
        idleGameManager = IdleGameManager.Instance;

        PopulateDisplay();
    }

    private void PopulateDisplay()
    {
        for(int i = 0; i < idleGameManager.CurrentSaveData.Achievements.Count; i++)
        {
            GameObject newAchievementDisplay = Instantiate(AchievementDisplayPrefab, AchievementDisplayParent.transform);
            AchievementDisplayController controller = newAchievementDisplay.GetComponent<AchievementDisplayController>();
            controller.Setup(idleGameManager.CurrentSaveData.Achievements[i]);
        }
    }
}
