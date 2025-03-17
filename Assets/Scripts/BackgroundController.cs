using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject background_1;
    public GameObject background_2;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("background 1");
            background_1.SetActive(true);
            background_2.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("background 2");
            background_1.SetActive(false);
            background_2.SetActive(true);
        }
    }

    public void BackgroundIndex()
    {
        
    }
}
