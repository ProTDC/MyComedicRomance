using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    //This script is for settings button in gameplay mode
    [SerializeField] private Button gameSettingsButton;
    [SerializeField] private GameObject settingsMenu;

    private void Start()
    {
        gameSettingsButton.GetComponent<Button>();
    }

    public void EnterIngameSettings()
    {
        Debug.Log("Entering Settings");
        gameSettingsButton.interactable = false;
        settingsMenu.SetActive(true);
    }

    public void ExitIngameSettings() {gameSettingsButton.interactable = true;}
}
