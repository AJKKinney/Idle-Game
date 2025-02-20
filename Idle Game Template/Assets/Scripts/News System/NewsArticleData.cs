using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NewsArticleData
{
    [SerializeField] private string newsText;
    [SerializeField] private string sourceText;

    #region Getters & Setters

    public string NewsText { get => newsText; set => newsText = value; }
    public string SourceText { get => sourceText; set => sourceText = value; }

    #endregion
}
