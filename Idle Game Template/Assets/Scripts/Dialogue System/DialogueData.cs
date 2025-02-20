using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 50)]
[System.Serializable]
public class DialogueData : ScriptableObject
{
    //[TextArea(3,15)]
    [SerializeField] private List<DialogueChunk> dialogueChunks = new List<DialogueChunk>();

    #region Getters & Setters

    public List<DialogueChunk> DialogueChunks { get => dialogueChunks; set => dialogueChunks = value; }

    #endregion
}
