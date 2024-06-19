using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    private UIDocument document;

    private Button startButton;
    private Button settingsButton;
    private Button creditsButton;
    private Button exitButton;
    
    private Button settingsBackButton;
    private Button creditsBackButton;
    
    private VisualElement settingsView;
    private VisualElement creditsView;
    
    private AudioSource audioSource;
    [FormerlySerializedAs("_clickSounds")] public List<AudioClip> clickSounds;
    
    private List<Button> buttons = new List<Button>();
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        document = GetComponent<UIDocument>();
        
        settingsView = document.rootVisualElement.Q<VisualElement>("SettingsView");
        creditsView = document.rootVisualElement.Q<VisualElement>("CreditsView");
        
        buttons = document.rootVisualElement.Query<Button>().ToList();
        
        foreach (var button in buttons)
        {
            button.clickable.clicked += () =>
            {
                if (clickSounds.Any())
                {
                    audioSource.PlayOneShot(clickSounds[Random.Range(0, clickSounds.Count)]); // Play a random click sound
                }
            };
        }
        
        // Start Button
        startButton = document.rootVisualElement.Q<Button>("Start");
        startButton.clickable.clicked += () =>
        {
            Debug.Log("Start Clicked");
            StartGame();
        };
        
        // Settings Button
        settingsButton = document.rootVisualElement.Q<Button>("Settings");
        settingsButton.clickable.clicked += () =>
        {
            settingsView.AddToClassList("SettingsActive");
            Debug.Log("Button Clicked");
        };
        
        // Settings Back Button
        settingsBackButton = document.rootVisualElement.Q<Button>("SettingsBack");
        settingsBackButton.clickable.clicked += () =>
        {
            settingsView.RemoveFromClassList("SettingsActive");
            Debug.Log("Button Clicked");
        };
        
        // Credits Button
        creditsButton = document.rootVisualElement.Q<Button>("Credits");
        creditsButton.clickable.clicked += () =>
        {
            creditsView.AddToClassList("CreditsActive");
            Debug.Log("Button Clicked");
        };
        
        // Credits Back Button
        creditsBackButton = document.rootVisualElement.Q<Button>("CreditsBack");
        creditsBackButton.clickable.clicked += () =>
        {
            creditsView.RemoveFromClassList("CreditsActive");
            Debug.Log("Button Clicked");
        };
        
        // Exit Button
        exitButton = document.rootVisualElement.Q<Button>("Exit");
        exitButton.clickable.clicked += () =>
        {
            Application.Quit();
        };
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene
    }

}
