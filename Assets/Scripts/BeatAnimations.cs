using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatAnimations : MonoBehaviour {

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ToTheBeat ()
    {
        //trigger the animation for the beat.
    }
}
