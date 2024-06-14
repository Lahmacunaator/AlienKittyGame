using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Colorinator : MonoBehaviour
{
    public Volume volume;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (volume.profile.TryGet(out ColorAdjustments colorAdjustments))
            {
                colorAdjustments.saturation.value = -100f;
            }
        }
    }
}
