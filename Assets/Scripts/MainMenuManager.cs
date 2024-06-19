using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button ExitButton;
    
    // Start is called before the first frame update
    void Awake()
    {
        StartButton.onClick.AddListener(OnStartButton);
        ExitButton.onClick.AddListener(OnExitButton);
    }

    void OnDestroy()
    {
        StartButton.onClick.RemoveAllListeners();
        ExitButton.onClick.RemoveAllListeners();
    }

    private void OnStartButton()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
    private void OnExitButton()
    {
        Application.Quit();   
    }
}
