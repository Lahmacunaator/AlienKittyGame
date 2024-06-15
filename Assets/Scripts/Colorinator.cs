using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Colorinator : MonoBehaviour
{
    private Volume volume;

    private void Awake()
    {
        volume = GetComponent<Volume>();
    }

    public void AdjustSaturation(float value)
    {
        if (volume.profile.TryGet(out ColorAdjustments colorAdjustments))
        {
            colorAdjustments.saturation.value = value;
        }
    }
}
