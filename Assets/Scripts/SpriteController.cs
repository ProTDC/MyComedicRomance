using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private SpriteRenderer _characterSprite;
    //Reference to total amount of sprites for a character
    public Sprite[] sprites;
    //Current sprite on display
    private int currentSprite = 0;
    
    void Start()
    {
        _characterSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }
}
