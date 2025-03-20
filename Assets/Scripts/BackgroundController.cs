using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //Background names, can be changed later for easier sorting
    public GameObject background_1;
    public GameObject background_2;
    public GameObject background_3;
    //Controls what background is active/disabled
    public int currentBackground;
    
    void Update()
    {
        if (currentBackground == 0)
        {
            background_1.SetActive(true);
            background_2.SetActive(false);
            background_3.SetActive(false);
        }

        if (currentBackground == 1)
        {
            background_1.SetActive(false);
            background_2.SetActive(true);
            background_3.SetActive(false);
        }

        if (currentBackground == 2)
        {
            background_1.SetActive(false);
            background_2.SetActive(false);
            background_3.SetActive(true);
        }
    }
}
