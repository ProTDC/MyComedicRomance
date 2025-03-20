using System;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public SpriteRenderer background;
    public Sprite [] backgrounds;
    //Controls what background is displayed
    public int currentBackground;

    private void Start()
    {
        background = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        background.sprite = backgrounds [currentBackground];
    }
}
