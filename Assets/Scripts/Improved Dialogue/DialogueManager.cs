using System;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    
    public GameObject dialogueParent;
    public TextMeshProUGUI dialogueTitleText, dialogueBodyText;
    public GameObject responseButtonPrefab;
    public Transform responseButtonsContainer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        HideDialogue();
    }

    public void StartDialogue(string title, DialogueNode node)
    {
        ShowDialogue();
        
        dialogueTitleText.text = title;
        dialogueBodyText.text = node.dialogueText;

        foreach (Transform child in responseButtonsContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (DialogueResponse response in node.responses)
        {
            GameObject buttonObj = Instantiate(responseButtonPrefab, responseButtonsContainer);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = response.responseText;
            
            Button button = buttonObj.GetComponent<Button>();
            button.onClick.AddListener(() => SelectResponses(response, title));
        }
    }

    void Clicked()
    {
        Debug.Log("Clicked");
    }

    public void SelectResponses(DialogueResponse response, string title)
    {
        if (!response.nextNode.IsLastNode())
        {
            StartDialogue(title, response.nextNode);
        }
        else
        {
            HideDialogue();
        }
    }

    public void ShowDialogue()
    {
        dialogueParent.SetActive(true);
    }

    public void HideDialogue()
    {
        dialogueParent.SetActive(false);
    }

    public bool IsDialogueActive()
    {
        return dialogueParent.activeSelf;
    }
}
