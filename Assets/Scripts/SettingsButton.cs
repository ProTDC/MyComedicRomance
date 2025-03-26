using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    //This script is for settings button in gameplay mode
    [SerializeField] private GameObject gameSettingsButton;
    [SerializeField] private GameObject settingsMenu;

    public void EnterIngameSettings()
    {
        Debug.Log("Entering Settings");
        gameSettingsButton.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ExitIngameSettings() {gameSettingsButton.SetActive(true);}
}
