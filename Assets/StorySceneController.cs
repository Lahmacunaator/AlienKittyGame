using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySceneController : MonoBehaviour
{
    [SerializeField] private LevelSwitcharoo levelSwitcher;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            levelSwitcher.GoToNextLevel();
        }
    }
}
