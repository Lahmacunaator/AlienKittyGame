using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcharoo : MonoBehaviour
{
    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;

    private void Start()
    {
        _startingSceneTransition.SetActive(true);
        Destroy(_startingSceneTransition, 2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            GoToNextLevel();
        }
    }

    public void GoToNextLevel()
    {
        StartCoroutine(WaitAndExecute(2));
    }
    
    // This is the coroutine
    private IEnumerator WaitAndExecute(float waitTime)
    {
        _endingSceneTransition.SetActive(true);
        
        // Wait for the specified amount of time
        yield return new WaitForSeconds(waitTime);
        

        var index = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadSceneAsync(index);
    }
}
