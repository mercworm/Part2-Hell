using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ScreenShake : MonoBehaviour {

    public Transform camTrans;
    public bool shaking = false;
    public float shakeAmount;

    public Vector3 origPos;

    public PostProcessingBehaviour postScript;
    public PostProcessingProfile shake, normal, sketch;

    private bool mouthShake = false;
    public float shakeDuration;
    public float decreaseFactor;

    private void OnEnable()
    {
        EventManager.StartListening("ShakeOn", StartShake);
        EventManager.StartListening("ShakeOff", StopShake);
        EventManager.StartListening("OnMouthClose", MouthShake);
    }

    private void Start()
    {
        postScript = GetComponent<PostProcessingBehaviour>();
    }

    void Update () {

        if (shaking)
        {
            camTrans.localPosition = origPos + Random.insideUnitSphere * shakeAmount;
            postScript.profile = shake;
        }
        else if (!shaking && !mouthShake)
        {
            camTrans.localPosition = origPos;
            postScript.profile = normal;
        }

        if(mouthShake)
        {
            if (shakeDuration > 0)
            {
                camTrans.localPosition = origPos + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 0f;
                camTrans.localPosition = origPos;
                mouthShake = false;
            }
        }
	}

    public void StartShake ()
    {
        shaking = true;
    }

    public void StopShake ()
    {
        shaking = false;
    }

    private void OnDisable()
    {
        EventManager.StopListening("ShakeOn", StartShake);
        EventManager.StopListening("ShakeOff", StopShake);
    }

    public void MouthShake ()
    {
        shakeDuration = .2f;
        mouthShake = true;
    }

    public void SketchPostEffectOn ()
    {
        postScript.profile = sketch;
    }

    public void SketchPostEffectOff ()
    {
        postScript.profile = normal;
    }
}
