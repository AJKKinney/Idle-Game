using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickerIncomePoolController : MonoBehaviour
{
    [SerializeField] private GameObject clickerIncomeIndicatorTextPrefab;
    [SerializeField] private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        ClickerButtonController.onClickedClicker += CreateIncomeIndicator;
    }

    private void CreateIncomeIndicator(List<float> amount, List<ResourceType> type, LocationType location)
    {
        for (int i = 0; i < amount.Count; i++)
        {
            GameObject newIndicatorText = Instantiate(clickerIncomeIndicatorTextPrefab, canvas.transform);
            //RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out Vector3 worldPoint);
            //newIndicatorText.transform.position = worldPoint;
            newIndicatorText.transform.position = Input.mousePosition;
            TextMeshProUGUI textMesh = newIndicatorText.GetComponent<TextMeshProUGUI>();
            textMesh.text = "+" + amount[i].ToString("0") + type[i].ToString();
        }
    }
}
