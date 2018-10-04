﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D rb2d;

    public float playerSpeed;

    public bool canMove = true;
    public bool mouthOpen = false;

    private bool actOnce = true;

    public GameObject toothPrefab;
    public Transform spawnPoint;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	private void FixedUpdate()
    {
        if(canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            rb2d.AddForce(movement * playerSpeed);

            if(Input.GetKeyDown(KeyCode.F))
            {
                mouthOpen = true;
            }

            if(Input.GetKeyUp(KeyCode.F))
            {
                mouthOpen = false;
            }
        }

        if (mouthOpen)
        {
            //Set animation bool for the mouth to true.
            if (actOnce)
            {
                actOnce = false;
                InvokeRepeating("TeethSpawn", 0.3f, 0.3f);
            }
        }
        else
        {
            //set animation bool for the mouth to false.
            CancelInvoke();
            actOnce = true;
        }
    }

    //Spawn the teeth.
    //The take care of the movement themselves.
    public void TeethSpawn ()
    {
        Instantiate(toothPrefab, spawnPoint);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Acid"))
        {
            //trigger the animation "melting" the bones away.
            //start the particle effect making it look like the skin is disappearing.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Acid"))
        {
            //trigger the animation butting the character back together.
            //start the particle effect making it look like the skin goes back on the body.
        }
    }
}