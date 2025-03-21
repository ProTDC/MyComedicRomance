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
    }

    public void ChangeSprite(int sprite)
    {
        currentSprite = sprite;
        image.sprite = sprites[currentSprite];
    }
}
