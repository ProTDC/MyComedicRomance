using System;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public string Name;
    public Dialogue Dialogue;

    private void Start()
    {
        Invoke(nameof(SpeakTo), 1f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpeakTo();
        }
    }

    public void SpeakTo()
    {
        DialogueManager.Instance.StartDialogue(Name, Dialogue.RootNode);
    }
}
