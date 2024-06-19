using UnityEngine;

public class ScreenSplit : MonoBehaviour
{
    [SerializeField] private Camera camera; 
    [SerializeField] private Camera cameraTwo;
    
    // Start is called before the first frame update
    void Start()
    {
        camera.rect = new Rect(0,0,0.5f,1);
        cameraTwo.rect = new Rect(0.5f,0,0.5f,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
