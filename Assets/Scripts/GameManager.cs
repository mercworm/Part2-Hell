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
    //public BeatEvents OnBeat;
    //public BeatEvents OnDoubleBeat;
    public BeatEvents OnIntensityIncrease;
    public BeatEvents EndEvent;
    public BeatEvents OnSketchEnd;
    public BeatEvents OnHeart;
    public BeatEvents OnMouth;
    public BeatEvents OnAcid;

    private bool intensity = true;
    public static bool sketch = false;
    private bool end = true;
    private bool end2 = true;
    private bool heart = true;
    private bool mouth = true;
    private bool acid = true;

    public bool testSketch = false;

    public GameObject blackscreen;
    public GameObject transitionScreen;

    public AudioSource effectSource;
    public AudioClip beepClip;

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
            //OnBeat.Invoke();
            EventManager.TriggerEvent("OnBeat");
            Debug.Log("Beat");

            everyBeatTimer -= (60f / bpm);
        }

        if(doubleBeatTimer >= (120f/bpm))
        {
            //OnDoubleBeat.Invoke();
            EventManager.TriggerEvent("OnDoubleBeat");
            Debug.Log("Double Beat");
            doubleBeatTimer -= (120f / bpm);
        }
        
        lastTime = GetComponent<AudioSource>().time;

        // the followin ifs checks for all the major events that will happen throughout the game using lastTime
        //mouth, heart, skethc-phase, end, etc.
        
        //spawns the mouth
        if(lastTime >= 20f && lastTime <= 22f && mouth)
        {
            OnMouth.Invoke();
        }
        //Start the sketch-phase
        else if(lastTime >= 40f && lastTime <= 42f && !sketch)
        {
            StopAllCoroutines();
            StartCoroutine(Transition("SwitchToSketch"));
            sketch = true;
            testSketch = true;
        }
        //end the sketch-phase
        //also start spawning blisters
        else if(lastTime >= 70f && lastTime <= 72f && sketch)
        {
            StopAllCoroutines();
            StartCoroutine(Transition("SwitchBack"));
            sketch = false;
            testSketch = false;
            OnSketchEnd.Invoke();
        }
        //spawn the heart
        else if(lastTime >= 74 && lastTime <= 76f && heart)
        {
            //setactive the heart and make cogs start spawning
            heart = false;
            OnHeart.Invoke();
        }
        //start spin
        //stop spawning blisters
        else if (lastTime >= 122f && intensity)
        {
            OnIntensityIncrease.Invoke();
            intensity = false;
        }
        //spawn the worm butt
        else if (lastTime >= 197f && end2)
        {
            end2 = false;
            EndEvent.Invoke();
        }
        //fade out
        else if(lastTime >= 206f && end)
        {
            end = false;
            StartCoroutine(EndItAll());
        }

        //the following ifs takes care of spawning the acid, since we can no longer have that randomized
        //spawns 7 times during the game
        if (lastTime >= 25f && lastTime <= 27f && acid)
        {
            Debug.Log("Acid Should Spawn");
            StartCoroutine(AcidCheck());
        }
        else if (lastTime >= 45f && lastTime <= 47f && acid) StartCoroutine(AcidCheck());
        else if (lastTime >= 56f && lastTime <= 57f && acid) StartCoroutine(AcidCheck());
        else if (lastTime >= 82f && lastTime <= 84f && acid) StartCoroutine(AcidCheck());
        else if (lastTime >= 140f && lastTime <= 142f && acid) StartCoroutine(AcidCheck());
        else if (lastTime >= 170f && lastTime <= 172f && acid) StartCoroutine(AcidCheck());
    }

    public IEnumerator EndItAll ()
    {
        blackscreen.SetActive(true);
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
    }

    public IEnumerator Transition (string triggerName)
    {
        transitionScreen.SetActive(true);
        effectSource.clip = beepClip;
        effectSource.Play();
        yield return new WaitForSeconds(2);
        EventManager.TriggerEvent(triggerName);
        effectSource.Stop();
        transitionScreen.SetActive(false);
    }

    public IEnumerator AcidCheck ()
    {
        acid = false;
        OnAcid.Invoke();
        yield return new WaitForSeconds(2);
        acid = true;
    }
}
