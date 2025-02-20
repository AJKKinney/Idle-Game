using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using AustenKinney.Essentials;


public class ClickerButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] LocationType location;
    [SerializeField] private List<ResourceType> resourceTypesGenerated = new List<ResourceType>();
    [SerializeField] private List<float> resourceAmountsGenerated = new List<float>();

    [SerializeField] private AudioClip onPointerDownSFX;
    [SerializeField] private AudioClip OnPointerUpSFX;
    [SerializeField] private AudioClip OnMouseOverSFX;
    [SerializeField] private AudioClip OnMouseExitSFX;

    private AudioManager audioManager;

    private Button button;
    private IdleGameManager idleGameManager;
    private AchievementManager achievementManager;
    private RectTransform rect;

    private Vector2 targetSize;
    private Vector2 cachedSize;
    private float easingTime = 1f;
    private float easingTimer;

    private bool pointerUp = false;

    #region Getters & Setters

    public List<ResourceType> ResourceTypesGenerated { get => resourceTypesGenerated; set => resourceTypesGenerated = value; }
    public List<float> ResourceAmountsGenerated { get => resourceAmountsGenerated; set => resourceAmountsGenerated = value; }

    #endregion



    public delegate void OnClickedClicker(List<float> resouceAmounts, List<ResourceType> resourceTypes, LocationType location);
    public static event OnClickedClicker onClickedClicker;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        rect = GetComponent<RectTransform>();

        cachedSize = rect.sizeDelta;
        targetSize = cachedSize;

        idleGameManager = IdleGameManager.Instance;
        achievementManager = AchievementManager.Instance;
        audioManager = AudioManager.Instance;

        onClickedClicker += achievementManager.Statistics.TrackClick;
    }

    private void Update()
    {
        if(easingTimer > 0)
        {
            rect.sizeDelta = Vector2.LerpUnclamped(cachedSize, targetSize, EasingFunctions.Elastic(easingTime - easingTimer / easingTime));

            easingTimer -= Time.deltaTime;
        }
    }

    private void OnClick()
    {
        for (int i = 0; i < ResourceTypesGenerated.Count; i ++)
        {
            idleGameManager.GainResource(ResourceTypesGenerated[i], ResourceAmountsGenerated[i]);
            if (onClickedClicker != null)
            {
                onClickedClicker.Invoke(resourceAmountsGenerated, resourceTypesGenerated, location);
            }
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        cachedSize = rect.sizeDelta;
        targetSize *= 1.1f;
        easingTimer = easingTime;


        if (pointerUp == true)
        {
            pointerUp = false;

            return;
        }
        audioManager.PlaySFX(OnMouseOverSFX);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cachedSize = rect.sizeDelta;
        targetSize /= 1.1f;
        easingTimer = easingTime;


        if (pointerUp == true)
        {
            return;
        }
        audioManager.PlaySFX(OnMouseExitSFX);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        cachedSize = rect.sizeDelta;
        targetSize *= 0.8f;
        easingTimer = easingTime;

        audioManager.PlaySFX(onPointerDownSFX);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        cachedSize = rect.sizeDelta;
        targetSize /= 0.8f;
        easingTimer = easingTime;

        audioManager.PlaySFX(OnPointerUpSFX);

        pointerUp = true;
    }


}
