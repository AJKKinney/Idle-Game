using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickerIncomeIndicatorTextController : MonoBehaviour
{
    [SerializeField] private float initialMovementSpeed = 500f;
    [SerializeField] private float lifetime = 0.5f;
    [SerializeField] private float fadeoutTime = 0.25f;

    private RectTransform rect;
    private TextMeshProUGUI textMesh;

    private float lifetimeTimer;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        textMesh = GetComponent<TextMeshProUGUI>();

        lifetimeTimer = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetimeTimer > 0)
        {
            rect.position += new Vector3(0, initialMovementSpeed * lifetimeTimer / lifetime * Time.deltaTime, 0);
            lifetimeTimer -= Time.deltaTime;

            if (lifetimeTimer < fadeoutTime)
            {
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, lifetimeTimer / fadeoutTime);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

