using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatAnimations : MonoBehaviour {

    public Animator anim;
    public string animName;

    public void ToTheBeat ()
    {
        anim.SetTrigger(animName);
    }
}
