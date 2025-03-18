using UnityEngine;
using UnityEngine.Serialization;

public class SpriteController : MonoBehaviour
{
    public SpriteRenderer characterSprite;
    //Reference to total amount of sprites for a character
    public Sprite[] sprites;
    //Current sprite on display
    public int currentSprite = 0;
    
    void Start()
    {
        characterSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        //Controls what the current sprite is (temporary)
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentSprite += 1;
            if (currentSprite > 4)
                currentSprite = 0;
            characterSprite.sprite = sprites[currentSprite];
        }
    }
}
