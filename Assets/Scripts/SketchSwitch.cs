using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SketchSwitch : MonoBehaviour {

    public GameObject sketchVersion, normalVersion;
    private bool switchDone = false;

    private void OnEnable()
    {
        EventManager.StartListening("SwitchToSketch", Switch);
    }
	
	// Update is called once per frame
	void Update () {
		if (GameManager.sketch && !switchDone)
        {
            Switch();
            switchDone = true;
        }
        if(!GameManager.sketch)
        {
            sketchVersion.SetActive(false);
            normalVersion.SetActive(true);
        }
	}

    public void Switch()
    {
        sketchVersion.SetActive(true);
        normalVersion.SetActive(false);
    }
}
