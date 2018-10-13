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
    private bool end = true;

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

        if(lastTime >= 50f && lastTime <= 52f && !sketch)
        {
            StopAllCoroutines();
            StartCoroutine(Transition("SwitchToSketch"));
            sketch = true;
            testSketch = true;
            //Debug.Log("switching to sketch every update");
        }

        if(lastTime >= 80f && lastTime <= 82f && sketch)
        {
            StopAllCoroutines();
            StartCoroutine(Transition("SwitchBack"));
            sketch = false;
            testSketch = false;
        }

        if(lastTime >= 206f && end)
        {
            end = false;
            StartCoroutine(EndItAll());
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
}
