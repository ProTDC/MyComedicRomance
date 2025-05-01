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
        ChangeOpacity(1, false);
        
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
    
    public void ChangeOpacity(int opacity, bool fade)
    {
        if (opacity >= 1 && fade)
        {
            characterFade.Play("RemyFadein");
            image.color = new Color(1, 1, 1, opacity);
            Debug.Log("Fade In Triggered!");
        }
        else if (opacity <= 0 && fade)
        {
            characterFade.Play("RemyFadeout");
            image.color = new Color(1, 1, 1, opacity);
            
        }
        
        image.color = new Color(1, 1, 1, opacity);
    }
}
