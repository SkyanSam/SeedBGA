using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class PostProcessingController : MonoBehaviour
{
    Volume volume;
    Bloom bloom;
    Vignette vignette;
    LensDistortion lensDistortion;
    ChromaticAberration chromaticAberration;
    public float beatInterval;
    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet<Bloom>(out bloom);
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<LensDistortion>(out lensDistortion);
        volume.profile.TryGet<ChromaticAberration>(out chromaticAberration);
        
    }

    // Update is called once per frame
    void Update()
    {
        bloom.intensity.value = LeanTween.easeOutCirc(4f, 0f, Time.time % beatInterval);
        vignette.intensity.value = LeanTween.easeOutCirc(0.5f, 0f, Time.time % beatInterval);
        lensDistortion.intensity.value = LeanTween.easeOutCirc(-1f, 0f, Time.time % beatInterval);
        chromaticAberration.intensity.value = LeanTween.easeOutCirc(1f, 0f, Time.time % beatInterval);
    }
}
