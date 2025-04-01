using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class SpriteControllerUI : MonoBehaviour
{
    private Image image;
    public Sprite[] sprites;
    public int currentSprite = 0;
    
    
    
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        
        ChangeOpacity(0);
    }

    public void ChangeSprite(string spriteName)
    {
        ChangeOpacity(1);
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
    
    public void ChangeOpacity(int opacity)
    {
        image.color = new Color(1, 1, 1, opacity);
    }
}
