using System.Collections;
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
        StartCoroutine(waitThenPlay());
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
        StartCoroutine(waitThenQuit());
    }

    IEnumerator waitThenPlay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
    
    IEnumerator waitThenQuit()
    {
        yield return new WaitForSeconds(2);
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
