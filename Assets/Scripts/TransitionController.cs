using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    private Material mat;
    private bool shouldDoTransition;
    private bool isReversed;
    
    // Start and end values for the interpolation
    private float startValue = -2.0f;
    private float endValue = 2.0f;

    // Duration of the interpolation
    public float duration = 2.0f;

    // Keep track of time
    private float timeElapsed = 0.0f;
    
    void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    public void InitiateEpicTransition() => shouldDoTransition = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InitiateEpicTransition();
        }
        
        if (!shouldDoTransition) return;
        DoTransition();
    }

    private void DoTransition()
    {
        // Increase the elapsed time
        timeElapsed += Time.deltaTime;

        // Calculate the interpolation factor (t) between 0 and 1
        var t = timeElapsed / duration;

        // Interpolate the value
        var currentValue = isReversed ? Mathf.Lerp(endValue, startValue, t) : Mathf.Lerp(startValue, endValue, t);

        mat.SetFloat("_DiffuseTransition", currentValue);
        
        // Reset the elapsed time if the duration has been reached
        if (!(timeElapsed > duration)) return;
        shouldDoTransition = false;
        isReversed = !isReversed;
        timeElapsed = 0.0f;
    }
}
