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
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        var bubble = Instantiate(bubblePrefab, gameObject.transform);
        yield return new WaitForSeconds(1);

        if (bubble == null) yield break;
        else bubble.transform.parent = null;
    }
}
