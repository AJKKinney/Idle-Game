using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Speaker", menuName = "Speaker", order = 63)]
public class SpeakerData : ScriptableObject
{
    [SerializeField] private Sprite speakerImage;
    [SerializeField] private string speakerName;
    [SerializeField] private List<AudioClip> speakerSFX = new List<AudioClip>();

    #region Getters & Setters

    public Sprite SpeakerImage { get => speakerImage; set => speakerImage = value; }
    public string SpeakerName { get => speakerName; set => speakerName = value; }
    public List<AudioClip> SpeakerSFX { get => speakerSFX; set => speakerSFX = value; }

    #endregion
}
