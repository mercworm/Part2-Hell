using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NippoBehaviour : MonoBehaviour {

    public GameObject bubblePrefab;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnBubble", 0f, 4f);
	}

    public void SpawnBubble ()
    {
        Instantiate(bubblePrefab, gameObject.transform);
    }
}
