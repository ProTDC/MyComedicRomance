using System;
using System.Collections;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public SpriteRenderer background;
    public Sprite [] backgrounds;
    public int currentBackground;
    public int lastBackground;
    public Animator fade;

    private void Start()
    {
        background = gameObject.GetComponent<SpriteRenderer>();
        lastBackground = currentBackground;
    }

    void Update()
    {
        if (lastBackground != currentBackground)
        {
            lastBackground = currentBackground;
            ChangeBackground();
        }
    }
    
    void ChangeBackground()
    {
        StartCoroutine(FadeEffect());
    }

    IEnumerator FadeEffect()
    {
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        background.sprite = backgrounds[currentBackground];
        fade.SetTrigger("FadeIn");
    }
}
