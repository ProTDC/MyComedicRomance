using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class SpriteControllerRemyUI : MonoBehaviour
{
    private Image image;
    public Sprite[] sprites;
    public int currentSprite = 0;
    public Animator characterFade;
    
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    public void ChangeSpriteRemy(string spriteName)
    {
        switch (spriteName)
        {
            case "neutral":
                currentSprite = 0;
                break;
            case "call":
                currentSprite = 1;
                break;
            case "shy":
                currentSprite = 2;
                break;
            case "angi":
                currentSprite = 3;
                break;
        }
        image.sprite = sprites[currentSprite];
    }

    public void ChangeColor(float r, float g, float b, float a)
    {
        image.color = new Color(r, g, b, a);
    }
    
    public void ChangeOpacity(int opacity, bool fade)
    {
        if (opacity >= 1 && fade)
        {
            characterFade.Play("RemyFadein");
        }
        else if (opacity <= 0 && fade)
        {
            characterFade.Play("RemyFadeout");
            
        }
    }
}
