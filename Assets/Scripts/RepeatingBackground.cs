using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    public float backgroundHeight;
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y > backgroundHeight)
        {
            RepositionBackground();
        }
	}

    public void RepositionBackground ()
    {
        Vector2 backgroundOffset = new Vector2(0, backgroundHeight * 2f);
        transform.position = (Vector2)transform.position + backgroundOffset;
    }
}
