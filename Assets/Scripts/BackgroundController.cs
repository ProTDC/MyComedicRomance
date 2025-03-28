using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    public void RemyButton()
    {
        StartCoroutine(RemyRoute());
    }

    IEnumerator RemyRoute()
    {
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("RemiScene");
    }
}
