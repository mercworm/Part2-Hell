using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    public Transform camTrans;
    public bool shaking = false;
    public float shakeAmount;

    public Vector3 origPos;

    private void OnEnable()
    {
        EventManager.StartListening("ShakeOn", StartShake);
        EventManager.StartListening("ShakeOff", StopShake);
    }
	
	void Update () {

        if (shaking)
        {
            camTrans.localPosition = origPos + Random.insideUnitSphere * shakeAmount;
        }
        else if (!shaking) camTrans.localPosition = origPos;
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
