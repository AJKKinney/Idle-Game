using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using AustenKinney.Essentials;

public class InspectionManager : Singleton<InspectionManager>
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image inspectableIcon;
    [SerializeField] private GameObject statPanelPrefab;
    [SerializeField] private RectTransform canvas;

    private List<GameObject> currentStatPanels = new List<GameObject>();
    private RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();

        CloseInspectionPanel();
    }

    public void InspectElement(string title, string cost, string description, Sprite icon, List<string> stats, RectTransform rectTransform)
    {
        titleText.text = title;

        if(title == "")
        {
            titleText.gameObject.SetActive(false);
        }
        else
        {
            titleText.gameObject.SetActive(true);
        }

        costText.text = cost;

        if (cost == "")
        {
            costText.gameObject.SetActive(false);
        }
        else
        {
            costText.gameObject.SetActive(true);
        }

        descriptionText.text = description;

        if (description == "")
        {
            descriptionText.gameObject.SetActive(false);
        }
        else
        {
            descriptionText.gameObject.SetActive(true);
        }

        inspectableIcon.sprite = icon;

        if(icon == null)
        {
            inspectableIcon.gameObject.SetActive(false);
        }
        else
        {
            inspectableIcon.gameObject.SetActive(true);
        }

        RemoveStatsPanels();

        for(int i = 0; i < stats.Count; i++)
        {
            GameObject newStatPanel = Instantiate(statPanelPrefab, this.transform);
            TextMeshProUGUI statTextMesh = newStatPanel.GetComponentInChildren<TextMeshProUGUI>();
            statTextMesh.text = stats[i];
            currentStatPanels.Add(newStatPanel);
        }

        gameObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);

        Vector3 offset = new Vector3(rectTransform.rect.size.x / 2 , rectTransform.rect.size.y / 2, 0);

        

        //offset = new Vector3(rectTransform.sizeDelta.x / 2, rectTransform.sizeDelta.y / 2, 0);

        //RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas, offset, Camera.main, out Vector3 worldPoint);

        if(rectTransform.position.x - offset.x - rect.rect.size.x > 0)
        {
            transform.position = rectTransform.position - offset;
            //rect.position = rectTransform.position; //- offset;// -offset;
            //rect.localPosition -= of
        }
        else
        {
            transform.position = rectTransform.position - new Vector3(-offset.x - rect.rect.size.x, offset.y, 0);
            //rect.position = rectTransform.position; //- offset;// - new Vector3(-offset.x - rect.rect.size.x, offset.y, 0);
        }

    }
    
    public void CloseInspectionPanel()
    {
        gameObject.SetActive(false);

        RemoveStatsPanels();
    }

    public void RemoveStatsPanels()
    {
        for (int i = currentStatPanels.Count - 1; i >= 0; i--)
        {
            Destroy(currentStatPanels[i]);
            currentStatPanels.RemoveAt(i);
        }
    }
}
