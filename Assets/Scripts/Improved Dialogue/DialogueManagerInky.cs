using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManagerInky : MonoBehaviour
{
    public TextAsset inkFile;
    public GameObject[] nameTags;
    private Dictionary<string, int> nameTagDictionary = new Dictionary<string, int>();
    public TextMeshProUGUI message;
    public GameObject buttonPrefab;
    public GameObject optionPanel;

    public SpriteControllerUI spriteController;
    public BackgroundControllerUI backgroundController;
    
    static Story story;
    List<string> tags;
    private const string speakerTag = "speaker";
    private const string spriteTag = "sprite";
    private const string backgroundTag = "background";
    private const string visibilityTag = "visible";
    static Choice choiceSelected;
    public bool storyHalted = false;

    // Start is called before the first frame update
    void Start()
    {
        nameTagDictionary.Add("player", 0);
        nameTagDictionary.Add("remi", 1);
        nameTagDictionary.Add("ringmaster", 2);
        
        story = new Story(inkFile.text);
        tags = new List<string>();
        choiceSelected = null;
        
        Invoke(nameof(AdvanceDialogue), 1f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !storyHalted)
        {
            if(story.canContinue)
            {
                AdvanceDialogue();
            }
            else
            {
                FinishDialogue();
            }
        }
    }
    
    private void FinishDialogue()
    {
        Debug.Log("End of Dialogue!");
        SceneManager.LoadScene(2);
    }
    
    void AdvanceDialogue()
    {
        foreach (GameObject item in nameTags)
        {
            item.SetActive(false);
        }
        
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

        if (currentChoices.Count > 0)
        {
            storyHalted = true;
        }
        else
        {
            return;
        }
        
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
        
        storyHalted = false;
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
                case backgroundTag:
                    backgroundController.ChangeBackground(tagValue);
                    break;
                case speakerTag:
                    nameTags[nameTagDictionary[tagValue]].SetActive(true);
                    break;
                case spriteTag:
                    spriteController.ChangeSprite(tagValue);
                    break;
                case visibilityTag:
                    if (tagValue == "true")
                    {
                        spriteController.ChangeOpacity(1);
                    }
                    if (tagValue == "false")
                    {
                        spriteController.ChangeOpacity(0);
                    }
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }
    
}
