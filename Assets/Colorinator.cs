using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;
using FloatParameter = UnityEngine.Rendering.PostProcessing.FloatParameter;

public class Colorinator : MonoBehaviour
{
    public Volume volume;
    
    // Start is called before the first frame update
    void Start()
    {
        //volume = GetComponent<Volume>();
        var isFound = volume.profile.TryGet(out ColorAdjustments colorAdjustments);

        colorAdjustments.saturation.value = -100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
