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
        }
        
        backgroundImage.sprite = backgrounds[currentBackground];
        manager.storyHalted = false;
    }

}
