using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueChunk
{
    [TextArea(5, 25)]
    [SerializeField] private string dialogueText;
    [SerializeField] private SpeakerData speakerData;

    #region Getters & Setters 

    public string DialogueText { get => dialogueText; set => dialogueText = value; }
    public SpeakerData SpeakerData { get => speakerData; set => speakerData = value; }

    #endregion
}
