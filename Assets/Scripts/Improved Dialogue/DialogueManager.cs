using System;
using System.Collections;
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(node.dialogueText));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            dialogueBodyText.text = node.dialogueText;
        }

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

    IEnumerator TypeSentence(string sentence)
    {
        dialogueBodyText.text = string.Empty;

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueBodyText.text += letter;
            yield return new WaitForSeconds(.05f);
        }
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
