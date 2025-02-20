using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatisticsData
{
    private int timesClicked = 0;
    private int timesClickedCity = 0;
    private int timesClickedStudy = 0;
    private float totalResourcesGenerated = 0;
    private float totalGoldGenerated = 0;
    private float totalInflunceGenerated = 0;

    #region Getters & Setters

    public int TimesClicked { get => timesClicked; set => timesClicked = value; }
    public int TimesClickedCity { get => timesClickedCity; set => timesClickedCity = value; }
    public int TimesClickedStudy { get => timesClickedStudy; set => timesClickedStudy = value; }
    public float TotalResourcesGenerated { get => totalResourcesGenerated; set => totalResourcesGenerated = value; }
    public float TotalGoldGenerated { get => totalGoldGenerated; set => totalGoldGenerated = value; }
    public float TotalInflunceGenerated { get => totalInflunceGenerated; set => totalInflunceGenerated = value; }

    #endregion

    #region Events & Delegates

    public delegate void OnTrackedClick();
    public event OnTrackedClick onTrackedClick;

    public delegate void OnTrackedResourceGeneration();
    public event OnTrackedResourceGeneration onTrackedResourceGeneration;

    #endregion

    public void TrackClick(List<float> resourceAmounts, List<ResourceType> resourceTypes, LocationType location)
    {
        TimesClicked += 1;

        switch(location)
        {
            case LocationType.City:
                TimesClickedCity += 1;
                break;
            case LocationType.Study:
                TimesClickedStudy += 1;
                break;
        }

        for (int i = 0; i < resourceAmounts.Count; i++)
        {
            TotalResourcesGenerated += resourceAmounts[i];

            switch(resourceTypes[i])
            {
                case ResourceType.Gold:
                    TotalGoldGenerated += resourceAmounts[i];
                    break;
                case ResourceType.Influence:
                    TotalInflunceGenerated += resourceAmounts[i];
                    break;
            }
        }

        if(onTrackedClick != null)
        {
            onTrackedClick.Invoke();
        }
    }

    public void TrackResourcesGenerated()
    {


        if(onTrackedResourceGeneration != null)
        {
            onTrackedResourceGeneration.Invoke();
        }
    }
}
