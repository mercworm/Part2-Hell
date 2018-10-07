using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatAnimations : MonoBehaviour {

    public Animator anim;
    public string animName;

    private void OnEnable()
    {
        if(gameObject.CompareTag("Bubble"))
        {
            EventManager.StartListening("OnDoubleBeat", ToTheBeat);
        }
        else if(gameObject.CompareTag("Eye"))
        {
            EventManager.StartListening("OnBeat", ToTheBeat);
        }
    }

    private void OnDisable()
    {
        EventManager.StopListening("OnDoubleBeat", ToTheBeat);
        EventManager.StopListening("OnBeat", ToTheBeat);
    }

    public void ToTheBeat ()
    {
        anim.SetTrigger(animName);
    }
}
