using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBehaviour : MonoBehaviour {

    public GameObject player;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        else transform.right = player.transform.position - transform.position;
        
    }
}
