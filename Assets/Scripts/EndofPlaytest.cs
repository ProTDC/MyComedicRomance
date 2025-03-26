using UnityEngine;
using UnityEngine.SceneManagement;

public class EndofPlaytest : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(LoadMainMenu), 5f);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
