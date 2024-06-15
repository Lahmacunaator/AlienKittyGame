using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Colorinator : MonoBehaviour
{
    public Volume volume;
    public GameObject player;

    private HealthManager healthManager;
    
    // Start is called before the first frame update
    void Start()
    {
        healthManager = player.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (volume.profile.TryGet(out ColorAdjustments colorAdjustments))
        {
            colorAdjustments.saturation.value = healthManager.health - 100f;
        }
    }
}
