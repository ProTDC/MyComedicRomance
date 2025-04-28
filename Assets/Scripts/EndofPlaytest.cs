using System.Collections;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndofPlaytest : MonoBehaviour
{
    public Image remiImage;
    
    void Start()
    {
        StartCoroutine(WideRemi(0f, 1f, 8f));
        Invoke(nameof(LoadMainMenu), 8f);
    }

    IEnumerator WideRemi(float start, float end, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            remiImage.color = new Color(1f, 1f, 1f, Mathf.Lerp(start, end, normalizedTime));
        }

        yield return null;
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
