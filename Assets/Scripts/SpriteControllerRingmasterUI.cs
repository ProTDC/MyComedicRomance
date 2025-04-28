using UnityEngine;
using UnityEngine.UI;

public class SpriteControllerRingmasterUI : MonoBehaviour
{
    private Image image;
    public Sprite[] sprites;
    public int currentSprite = 0;

    void Start()
    {
        image = gameObject.GetComponent<Image>();

        ChangeOpacity(0);
    }

    public void ChangeSpriteRingmaster(string spriteName)
    {
        ChangeOpacity(1);

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
    
    public void ChangeOpacity(int opacity)
    {
        image.color = new Color(1, 1, 1, opacity);
    }
}
