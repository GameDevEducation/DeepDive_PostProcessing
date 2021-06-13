using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPVSwitcher : MonoBehaviour
{
    public PostProcessVolume Volume1;
    public PostProcessVolume Volume2;
    public AnimationCurve PPVBlending;
    public float BlendTime = 5f;

    float CurrentProgress = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // update the volume weights
        Volume1.weight = PPVBlending.Evaluate(CurrentProgress);
        Volume2.weight = 1f - Volume1.weight;        
    }

    // Update is called once per frame
    void Update()
    {
        // update the progress if needed
        if (CurrentProgress < 1f)
            CurrentProgress += Time.deltaTime / BlendTime;

        // update the volume weights
        Volume1.weight = PPVBlending.Evaluate(CurrentProgress);
        Volume2.weight = 1f - Volume1.weight;
    }
}
