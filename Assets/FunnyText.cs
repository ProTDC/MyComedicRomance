using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunnyText : MonoBehaviour
{
        private TextMeshProUGUI text;

    private string[] funnies = 
    {
        "You didn't honk enough...",
        "You snooze you lose!",
        "L + Ratio",
        "You are maidenless",
        "Negative aura",
        "Spontaneous Depression",
        "Consider being single forever",
        "Rizz?",
        "You left the circus...",
        "Sucks to suck",
        "Get rekt!",
        "ded",
        "Damn",
        "You thought you could date?",
        "Try again...",
        "Come back later...",
        "You are not loved",
        "You are all alone",
        "You died alone",
        "You died single",
        "You forgot how to breathe",
        "Does your mom even love you?",
        "Disintegrated",
        "Your fit is mid...",
        "What was That?",
        "Think about what you've done"
    };

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        string txt = funnies[Random.Range(0, funnies.Length)];
        text.text = txt;
        
        Invoke("LoadScene", 6f);
    }
    
    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
