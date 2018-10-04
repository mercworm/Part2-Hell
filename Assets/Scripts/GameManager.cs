﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public float bpm;
    public float lastTime, deltaTime, everyBeatTimer, doubleBeatTimer;
    public AudioSource source;

    [System.Serializable]
    public class BeatEvents : UnityEvent { }
    [SerializeField]
    public BeatEvents OnBeat;
    public BeatEvents OnDoubleBeat;
    public BeatEvents OnIntensityIncrease;

    void Start ()
    {
        lastTime = 0f;
        deltaTime = 0f;
        everyBeatTimer = 0f;
        doubleBeatTimer = 0f;
	}
	
	void Update ()
    {
        deltaTime = GetComponent<AudioSource>().time - lastTime;

        everyBeatTimer += deltaTime;
        doubleBeatTimer += deltaTime;

        if(everyBeatTimer >= (60f/bpm))
        {
            OnBeat.Invoke();
            everyBeatTimer -= (60f / bpm);
        }
        if(doubleBeatTimer >= (120f/bpm))
        {
            OnDoubleBeat.Invoke();
            doubleBeatTimer -= (120f / bpm);
        }

        lastTime = GetComponent<AudioSource>().time;
	}
}