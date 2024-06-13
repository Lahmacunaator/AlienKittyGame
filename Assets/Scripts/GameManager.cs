using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Private backing field for the singleton instance
    private static GameManager _instance;

    // Prefab reference for AudioManager
    public GameObject audioManagerPrefab;
    [HideInInspector]
    public AudioManager audioManager = null;
    
    // Public static property to access the singleton instance
    public static GameManager Instance
    {
        get
        {
            // Ensure the instance is initialized if it hasn't been already
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<GameManager>();

            if (_instance == null)
            {
                var singleton = new GameObject(nameof(GameManager));
                _instance = singleton.AddComponent<GameManager>();
                DontDestroyOnLoad(singleton);
            }
            return _instance;
        }
        private set => _instance = value;
    }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Check if instance already exists and destroy this one if it does
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Save this instance as the singleton instance
        Instance = this;

        // Set this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        
        // Instantiate the AudioManager if it doesn't already exist
        if (audioManager == null && audioManagerPrefab != null)
        {
            var instantiatedObject = Instantiate(audioManagerPrefab);
            audioManager = instantiatedObject.GetComponent<AudioManager>();
        }
    }

    // Other game manager methods can go here
}
