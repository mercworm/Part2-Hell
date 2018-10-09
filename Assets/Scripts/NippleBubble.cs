using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NippleBubble : MonoBehaviour {

    private ScrollingObject scroll;
    private BeatAnimations beat;

	// Use this for initialization
	void Start () {
        scroll = GetComponent<ScrollingObject>();
        beat = GetComponent<BeatAnimations>();

        StartCoroutine(TurnOnMovement());	}

    public IEnumerator TurnOnMovement ()
    {
        yield return new WaitForSeconds(1);
        scroll.enabled = true;
        beat.enabled = true;
    }
}
