using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueManagerInky : MonoBehaviour
{
    public TextAsset inkFile;
    public GameObject[] nameTags;
    private Dictionary<string, int> nameTagDictionary = new Dictionary<string, int>();
    private AudioManager audioManager;
    public TextMeshProUGUI message;
    public GameObject buttonPrefab;
    public GameObject optionPanel;
    public GameObject dialoguePanel;

    public SpriteControllerRemyUI spriteControllerRemy;
    public SpriteControllerRingmasterUI spriteControllerRingmaster;
    public BackgroundControllerUI backgroundController;
    
    static Story story;
    List<string> tags;
    private const string speakerTag = "speaker";
    private const string spriteTag = "sprite";
    private const string backgroundTag = "background";
    private const string musicTag = "music";
    private const string visibilityTag = "visibility";
    private const string ringmasterVisibilityTag = "ringmastervisibility";
    public bool storyHalted = false;
    private string currentCharacter = string.Empty;

    private const string wrongChoices = "wrongChoices";
    private bool failedRomance;

    private bool remiSpeaking;
    private bool ringmasterSpeaking;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        failedRomance = false;
        
        nameTagDictionary.Add("player", 0);
        nameTagDictionary.Add("remi", 1);
        nameTagDictionary.Add("ringmaster", 2);
        nameTagDictionary.Add("question", 3);
        
        story = new Story(inkFile.text);
        tags = new List<string>();

        if (spriteControllerRemy == null)
        {
            Debug.LogWarning("Remi's SpriteController is not set!");
        }
        if (spriteControllerRingmaster == null)
        {
            Debug.LogWarning("The Ringmaster's SpriteController is not set!");
        }
        if (backgroundController == null)
        {
            Debug.LogWarning("The BackgroundController is not set!");
        }
        
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

        int numberChoices = (int)story.variablesState[wrongChoices];

        if (numberChoices >= 4)
        {
            failedRomance = true;
        }
    }
    
    private void FinishDialogue()
    {
        Destroy(dialoguePanel);
        Destroy(message);
        
        if (!failedRomance && SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(3);
        }
        else if (failedRomance)
        {
            SceneManager.LoadScene(4);
        }

    }
    
    void AdvanceDialogue()
    {
        foreach (GameObject item in nameTags)
        {
            item.SetActive(false);
        }
        spriteControllerRingmaster.ChangeColor(.6f, .6f, .6f, 1f);
        spriteControllerRemy.ChangeColor(.6f, .6f, .6f, 1f);
        
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
                    currentCharacter = tagValue;
                    nameTags[nameTagDictionary[tagValue]].SetActive(true);
                    Debug.Log(tagValue);
                    
                    spriteControllerRingmaster.ChangeColor(.6f, .6f, .6f, 1f);
                    spriteControllerRemy.ChangeColor(.6f, .6f, .6f, 1f);
                    
                    if (tagValue == "remi")
                    {
                        Debug.Log("remi triggered!");
                        spriteControllerRemy.ChangeColor(1f, 1f, 1f, 1f);
                    }

                    if (tagValue == "ringmaster")
                    {
                        spriteControllerRingmaster.ChangeColor(1f, 1f, 1f, 1f);
                    }
                    break;
                
                case spriteTag:
                    if (currentCharacter == "remi" || currentCharacter == "question")
                    {
                        spriteControllerRemy.ChangeSpriteRemy(tagValue);
                    }
                    
                    if (currentCharacter == "ringmaster")
                    {
                        spriteControllerRingmaster.ChangeSpriteRingmaster(tagValue);
                    }
                    break;
                
                case musicTag:
                    Debug.Log(tagValue);
                    if (tagValue == "none")
                    {
                        audioManager.StopMusic();
                    }
                    else
                    {
                        audioManager.ChangeMusic(tagValue);
                    }
                    break;
                
                case visibilityTag:
                    if (tagValue == "true" )
                    {
                        spriteControllerRemy.ChangeOpacity(1, true);
                    }
                    if (tagValue == "false")
                    {
                        spriteControllerRemy.ChangeOpacity(0, true);
                    }
                    break;
                
                case ringmasterVisibilityTag:
                    if (tagValue == "true")
                    {
                        spriteControllerRingmaster.ChangeOpacity(1, true);
                    }
                    if (tagValue == "false")
                    {
                        spriteControllerRingmaster.ChangeOpacity(0, true);
                    }
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }
    
}
