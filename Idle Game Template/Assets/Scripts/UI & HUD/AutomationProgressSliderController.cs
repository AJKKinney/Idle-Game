using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomationProgressSliderController : MonoBehaviour
{
    private AutomationButtonController automationButtonController;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        automationButtonController = GetComponentInParent<AutomationButtonController>();
        automationButtonController.onTimerUpdated += UpdateSlider;
    }
    private void UpdateSlider(float progress)
    {
        slider.value = progress;
    }
}
