using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI newsText;
    [SerializeField] private TextMeshProUGUI sourceText;

    [SerializeField] private float articleDisplayTime;
    private float articleTimer;

    [SerializeField] private List<NewsArticleData> articlesInCirculation = new List<NewsArticleData>();
    private int displayedArticleIndex;

    private void Update()
    {
        if (articleTimer > 0)
        {
            articleTimer -= Time.deltaTime;
        }
        else
        {
            DisplayNewArticle();
            articleTimer = articleDisplayTime;
        }
    }

    private void DisplayNewArticle()
    {
        displayedArticleIndex += 1;
        if(displayedArticleIndex >= articlesInCirculation.Count)
        {
            displayedArticleIndex = 0;
        }

        newsText.text = articlesInCirculation[displayedArticleIndex].NewsText;
        sourceText.text = articlesInCirculation[displayedArticleIndex].SourceText;
    }
}
