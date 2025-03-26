using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitSettings : MonoBehaviour
{
    [SerializeField]private Button exitButton;
    [SerializeField]private MainMenuButtons mainMenu;
    [SerializeField]private SettingsButton gameplaySettings;

    private void Update()
    {
        exitButton.onClick.AddListener(QuitSettings);
    }

    private void QuitSettings()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainMenu")
        {
            Debug.Log("Exiting Menu Settings");
            gameObject.SetActive(false);
            mainMenu.OnExitSettings();
        }
        else
        {
            Debug.Log("Exiting Gameplay Settings");
            gameObject.SetActive(false);
            gameplaySettings.ExitIngameSettings();
        }
    }
}
