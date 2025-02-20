using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTester : MonoBehaviour
{
    [SerializeField] private DialogueData testDialogue;

    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.Instance.StartDialogue(testDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
