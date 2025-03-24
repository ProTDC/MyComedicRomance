using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject quitButton;
    
    
    public void PlayGame()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(1);
    }

    public void EnterSettings()
    {
        if (settingsMenu.activeInHierarchy) return;
        Debug.Log("Enter Settings");
        settingsButton.SetActive(false);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnExitSettings()
    {
        settingsButton.SetActive(true);
        playButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
