using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    
    
    
    public void PlayGame()
    {
        Debug.Log("Play");
        //SceneManager.LoadScene(insertSceneHere);
    }

    public void EnterSettings()
    {
        Debug.Log("Enter Settings");
        settingsMenu.SetActive(true);
        //Add function for initiating settings screen?
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
