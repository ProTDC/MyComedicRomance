using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ExitSettings : MonoBehaviour
{
    [SerializeField]private Button exitButton;
    [SerializeField]private MainMenuButtons mainMenu;

    private void Update()
    {
        exitButton.onClick.AddListener(QuitSettings);
    }

    private void QuitSettings()
    {
        gameObject.SetActive(false);
        mainMenu.OnExitSettings();
    }
}
