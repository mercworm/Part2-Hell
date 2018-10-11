using System.Collections;
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

    private bool intensity = true;
    public static bool sketch = false;

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
            EventManager.TriggerEvent("OnBeat");
            Debug.Log("Beat");

            everyBeatTimer -= (60f / bpm);
        }
        if(doubleBeatTimer >= (120f/bpm))
        {
            OnDoubleBeat.Invoke();
            EventManager.TriggerEvent("OnDoubleBeat");
            Debug.Log("Double Beat");
            doubleBeatTimer -= (120f / bpm);
        }
        
        lastTime = GetComponent<AudioSource>().time;

        if(lastTime >= 122f && intensity)
        {
            OnIntensityIncrease.Invoke();
            intensity = false;
        }

        if(lastTime >= 50 && sketch == false)
        {
            EventManager.TriggerEvent("SwitchToSketch");
            sketch = true;
            //Debug.Log("switching to sketch every update");
        }
	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 40, 40), "Every beat"))
        {
            OnBeat.Invoke();
        }

        if (GUI.Button(new Rect(10, 30, 40, 40), "Double"))
        {
            OnDoubleBeat.Invoke();
        }

        if(GUI.Button(new Rect(10, 50, 40, 40), "Increase"))
        {
            OnIntensityIncrease.Invoke();
        }
    }
}
