using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AustenKinney.Essentials;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private GameObject dialogueOverlay;
    [SerializeField] private Image speakerImage;
    [SerializeField] private TextMeshProUGUI speakerNameTextMesh;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private float textSpeed = 0.05f;

    private DialogueData currentDialogueData;
    private int currentDialogueChunkIndex;

    private bool readyToProgress = false;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    private void Update()
    {
        if (readyToProgress == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                ProgressDialogue();
            }
        }
    }

    public void StartDialogue(DialogueData data)
    {
        readyToProgress = true;
        currentDialogueData = data;
        speakerNameTextMesh.text = data.DialogueChunks[0].SpeakerData.SpeakerName;
        speakerImage.sprite = data.DialogueChunks[0].SpeakerData.SpeakerImage;
        dialogueText.text = "";
        currentDialogueChunkIndex = 0;
        dialogueOverlay.SetActive(true);
        StartCoroutine(PrintDialogue());
    }

    private void EndDialogue()
    {
        readyToProgress = false;
        currentDialogueData = null;
        currentDialogueChunkIndex = 0;
        dialogueOverlay.SetActive(false);
    }

    private void ProgressDialogue()
    {
        currentDialogueChunkIndex += 1;
        if (currentDialogueChunkIndex >= currentDialogueData.DialogueChunks.Count)
        {
            EndDialogue();
        }
        else
        {
            StartCoroutine(PrintDialogue());
        }
    }

    private IEnumerator PrintDialogue()
    {
        readyToProgress = false;

        string dialogue = "";

        for(int i = 0; i < currentDialogueData.DialogueChunks[currentDialogueChunkIndex].DialogueText.Length; i++)
        {
            char newChar = currentDialogueData.DialogueChunks[currentDialogueChunkIndex].DialogueText[i];

            dialogue += newChar;
            dialogueText.text = dialogue;

            if(char.IsWhiteSpace(newChar) == false)
            {
                audioManager.PlaySFX(currentDialogueData.DialogueChunks[currentDialogueChunkIndex].SpeakerData.SpeakerSFX[Random.Range(0, currentDialogueData.DialogueChunks[currentDialogueChunkIndex].SpeakerData.SpeakerSFX.Count)]);
            }

            yield return new WaitForSeconds(textSpeed);
        }

        readyToProgress = true;
    }
}
