﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public ObjectTypes bubble, nipple;
    public ObjectTypes[] eye, hands, blob, cog, dog;
    public GameObject acidObj;

    public Transform eyeSpawnPointLeft, eyeSpawnPointRight, handSpawnLeft, handSpawnRight, dogSpawnLeft, dogSpawnRight;

    private float countdown; //this is an ugly fix, but what can you do.

    private bool handsCheck = false;
    private bool blobCheck = false;
    private bool cogCheck = false;
    private bool acidCheck = true;
    private bool dogCheck = false;

    private void Start()
    {
        Invoke("SpawnStart", 4f);
        countdown = 0;
    }

    //failsafe making sure that the screen isn't covered by bubbles and nipples
    private void Update()
    {
        countdown += Time.deltaTime;
        if(countdown >= 20)
        {
            countdown = 0;
            CancelInvoke();
            Invoke("SpawnStart", 0f);
            if (handsCheck) Invoke("HandSpawnStart", 0f);
            if (blobCheck) Invoke("StartBlobSpawn", 0f);
            if (cogCheck) Invoke("StartCogSpawn", 0f);
            if (dogCheck) Invoke("DogSpawnStart", 0f);
        }
    }

    //start spawning hands when the spin begins
    public void HandSpawnStart ()
    {
        InvokeRepeating("HandSpawn", 0f, Random.Range(hands[0].minTime, hands[0].maxTime));
        handsCheck = true;
    }

    public void HandSpawnStop ()
    {
        CancelInvoke("HandSpawn");
    }

    public void HandSpawn ()
    {
        var handRotation = Random.Range(0, hands.Length);
        if (hands[handRotation].left)
        {
            Instantiate(hands[handRotation].objectPrefab[0], handSpawnLeft);
        }
        else
        {
            Instantiate(hands[handRotation].objectPrefab[0], handSpawnRight);
        }
    }

    //start spawning blisters after the sketch-phase
    public void StartBlobSpawn ()
    {
        InvokeRepeating("BounceBlob", 0f, Random.Range(hands[0].minTime, hands[0].maxTime));
        blobCheck = true;
    }

    public void StopBlobSpawn ()
    {
        CancelInvoke("BounceBlob");
        blobCheck = false;
    }

    public void BounceBlob ()
    {
        var blobRotation = Random.Range(0, blob.Length);
        if(blob[blobRotation].left)
        {
            Instantiate(blob[blobRotation].objectPrefab[0], handSpawnLeft);
        }
        else
        {
            Instantiate(blob[blobRotation].objectPrefab[0], handSpawnRight);
        }
    }

    //start spawning cogs when the heart is activated
    public void StartCogSpawn ()
    {
        InvokeRepeating("CogSpawn", 0f, Random.Range(cog[0].minTime, cog[0].maxTime));
        cogCheck = true;
    }

    public void CogSpawn ()
    {
        var cogRotation = Random.Range(0, cog.Length);
        var randomCog = Random.Range(0, cog[cogRotation].objectPrefab.Length);

        if(cog[cogRotation].left)
        {
            Instantiate(cog[cogRotation].objectPrefab[randomCog], eyeSpawnPointLeft);
        }
        else
        {
            Instantiate(cog[cogRotation].objectPrefab[randomCog], eyeSpawnPointRight);
        }
    }

    //start spawning everything else in the beginning
    public void SpawnStart()
    {
        //To spawn more different types, just add another invoke repeating, then add another corresponding void.
        InvokeRepeating("BubbleSpawn", 0f, Random.Range(bubble.minTime, bubble.maxTime));

        InvokeRepeating("EyeSpawn", 0f, Random.Range(eye[0].minTime, eye[0].maxTime));

        InvokeRepeating("NippleSpawn", 0f, Random.Range(nipple.minTime, nipple.maxTime));

        if (acidCheck)
        {
            Invoke("AcidSpawn", 0f);
        }
    }

    public void BubbleSpawn ()
    {
        //These both needs to be figured out when we have the screen done.
        var x = Random.Range(-3,3);
        var y = -54.2f;

        Vector3 spawn = new Vector3(x, y, 0f);
        
        Instantiate(bubble.objectPrefab[0], spawn, Quaternion.identity);

        InvokeRepeating("BubbleSpawn", Random.Range(bubble.minTime, bubble.maxTime), Random.Range(bubble.minTime, bubble.maxTime));
    }

    //Ok, so first we have to randomize if it's going to spawn a left or right eye.
    //Then we randomize color.
    //Then we spawn it on either the left or right wall, depending on the rotation.
    public void EyeSpawn ()
    {
        var eyeRotation = Random.Range(0, eye.Length);
        var randomEye = Random.Range(0, eye[eyeRotation].objectPrefab.Length);
        
        if(eye[eyeRotation].left)
        {
            Instantiate(eye[eyeRotation].objectPrefab[randomEye], eyeSpawnPointLeft);
        }
        else
        {
            Instantiate(eye[eyeRotation].objectPrefab[randomEye], eyeSpawnPointRight);
        }
    }

    public void NippleSpawn ()
    {
        var x = Random.Range(-3, 3);
        var y = -54.2f;

        Vector3 spawn = new Vector3(x, y, 0f);

        Instantiate(nipple.objectPrefab[0], spawn, Quaternion.identity);
    }

    public void AcidSpawn ()
    {
        acidCheck = false;
        Vector3 spawn = new Vector3(0f, -60f, 0f);

        Instantiate(acidObj, spawn, Quaternion.identity);
    }


    //same stuff again, but this time for the dogs.
    public void DogSpawnStart ()
    {
        InvokeRepeating("DogSpawn", 0f, Random.Range(dog[0].minTime, dog[0].maxTime));
        dogCheck = true;
    }

    public void DogSpawn ()
    {
        var dogRotation = Random.Range(0, dog.Length);
        if (dog[dogRotation].left)
        {
            Instantiate(dog[dogRotation].objectPrefab[0], dogSpawnLeft);
        }
        else
        {
            Instantiate(dog[dogRotation].objectPrefab[0], dogSpawnRight);
        }
    }

    public void DogSpawnStop ()
    {
        dogCheck = false;
        CancelInvoke("DogSpawn");
    }
}
