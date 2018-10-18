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
    public PostProcessingProfile shake, normal;

    private void OnEnable()
    {
        EventManager.StartListening("ShakeOn", StartShake);
        EventManager.StartListening("ShakeOff", StopShake);
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
        else if (!shaking)
        {
            camTrans.localPosition = origPos;
            postScript.profile = normal;
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
}
