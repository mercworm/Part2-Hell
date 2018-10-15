using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SketchSwitch : MonoBehaviour {

    public GameObject sketchVersion, normalVersion;
    private bool switchDone = false;

    public SpriteRenderer bubbleSpriteRend;
    public Sprite bubbleOrig, bubbleSketch;
    public Color origColor, sketchColor;

    private void OnEnable()
    {
        EventManager.StartListening("SwitchToSketch", Switch);
        EventManager.StartListening("SwitchBack", SwitchBack);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SwitchToSketch", Switch);
        EventManager.StopListening("SwitchBack", SwitchBack);
    }

    // Update is called once per frame
    void Update () {
		if (GameManager.sketch && !switchDone)
        {
            Switch();
            switchDone = true;
        }
	}

    public void Switch()
    {
        if (gameObject.tag == "Bubble")
        {
            bubbleSpriteRend.sprite = bubbleSketch;
            bubbleSpriteRend.color = sketchColor;
        }
        else
        {
            sketchVersion.SetActive(true);
            normalVersion.SetActive(false);
        }
    }

    public void SwitchBack ()
    {
        if (gameObject.tag == "Bubble")
        {
            bubbleSpriteRend.sprite = bubbleOrig;
            bubbleSpriteRend.color = origColor;
        }
        else
        {
            sketchVersion.SetActive(false);
            normalVersion.SetActive(true);
        }
    }
}
