using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterAudio : MonoBehaviour {

    public AudioLowPassFilter lowpass;

    private void OnEnable()
    {
        EventManager.StartListening("InAcid", Underwater);
        EventManager.StartListening("OutAcid", OverWater);
    }

    public void Underwater ()
    {
        Debug.Log("Entered acid");
        lowpass.cutoffFrequency = 933;
    }

    public void OverWater ()
    {
        lowpass.cutoffFrequency = 5000;
    }

}
