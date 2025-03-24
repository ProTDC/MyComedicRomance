using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManagerInky : MonoBehaviour
{
    public TextAsset inkFile;
    public TextMeshProUGUI nametag;
    public TextMeshProUGUI message;
    public GameObject buttonPrefab;
    private List<Button> choiceButtons = new List<Button>();
    public GameObject optionPanel;
    public bool isTalking = false;

    public SpriteControllerUI spriteController;
    
    static Story story;
    List<string> tags;
    private const string speakerTag = "speaker";
    private const string spriteTag = "sprite";
    static Choice choiceSelected;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkFile.text);
        tags = new List<string>();
        choiceSelected = null;
        
        Invoke(nameof(AdvanceDialogue), 1f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(story.canContinue)
            {
                AdvanceDialogue();
            }
            // else
            // {
            //     FinishDialogue();
            // }
        }
    }
    
    private void FinishDialogue()
    {
        Debug.Log("End of Dialogue!");
    }
    
    void AdvanceDialogue()
    {
        nametag.text = string.Empty;
        string currentSentence = story.Continue();
        ParseTags(story.currentTags);
        DisplayChoices();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
        }
        
        yield return null;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = story.currentChoices;
        
        if (optionPanel.transform.childCount > 0)
        {
            return;
        }
        
        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            int i2 = index;
            GameObject button = Instantiate(buttonPrefab, optionPanel.transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
            button.GetComponent<Button>().onClick.AddListener(() => MakeChoice(i2));
            index++;
        }
    }

    private void HideChoices()
    {
        foreach (Transform button in optionPanel.transform)
        {
            Destroy(button.gameObject);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        Debug.Log(choiceIndex);
        story.ChooseChoiceIndex(choiceIndex);
        AdvanceDialogue();
        HideChoices();
    }

    void ParseTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed:" + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case speakerTag:
                    nametag.text = tagValue;
                    break;
                case spriteTag:
                    spriteController.ChangeSprite(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }
    
}
