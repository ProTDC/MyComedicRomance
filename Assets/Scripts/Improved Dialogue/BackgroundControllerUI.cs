using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundControllerUI : MonoBehaviour
{
    private DialogueManagerInky manager;
    private Image backgroundImage;
    public Sprite[] backgrounds;
    public int currentBackground;

    public Animator anim;
    
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManagerInky>();
        
        backgroundImage = gameObject.GetComponent<Image>();
    }

    public void ChangeBackground(string newBackground)
    {
        StartCoroutine(BackgroundChangeWithFade(newBackground));
    } 

    private IEnumerator BackgroundChangeWithFade(string spriteName)
    {
        anim.SetTrigger("FadeTrigger");
        manager.storyHalted = true;
        
        yield return new WaitForSeconds(1f);
        
        switch (spriteName)
        {
            case "under1000":
                currentBackground = 0;
                break;
            case "bathroom":
                currentBackground = 1;
                break;
            case "under1000danger":
                currentBackground = 2;
                break;
            case "bathroomdanger":
                currentBackground = 3;
                break;
            case "trashbag":
                currentBackground = 4;
                break;
            case "cg1":
                currentBackground = 5;
                break;
            case "death":
                currentBackground = 6;
                break;
        }
        
        backgroundImage.sprite = backgrounds[currentBackground];
        manager.storyHalted = false;
    }

}
