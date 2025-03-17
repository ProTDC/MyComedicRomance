using System;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private DialogueManager manager;

    private void Start()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
        manager.StartDialogue(dialogue);
    }
}
