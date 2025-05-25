using UnityEngine;
using UnityEngine.UI;

public class SpriteControllerRingmasterUI : MonoBehaviour
{
    private Image image;
    public Sprite[] sprites;
    public int currentSprite = 0;
    public Animator characterFade;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    public void ChangeSpriteRingmaster(string spriteName)
    {
        switch (spriteName)
        {
            case "neutral":
                currentSprite = 0;
                break;
            case "angry":
                currentSprite = 1;
                break;
            case "shocked":
                currentSprite = 2;
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
            characterFade.Play("Fade_Start");
        }
        else if (opacity <= 0 && fade)
        {
            characterFade.Play("Fade_End");
            
        }
    }
}
