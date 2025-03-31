using UnityEngine;
using UnityEngine.UI;
public class QuitViaSettings : MonoBehaviour
{
    [SerializeField] private Button quitButton;

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
