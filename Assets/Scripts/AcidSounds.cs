using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSounds : MonoBehaviour {

    public AudioSource playSource, normalSource, muffledSource;
    public AudioClip bubbleFizz, sizzle, splat, pop, mouth, hands;

    private bool scream = true;

    private void OnEnable()
    {
        EventManager.StartListening("InAcid", SoundsGo);
        EventManager.StartListening("OutAcid", SoundStop);
        EventManager.StartListening("SplatSound", Splat);
        EventManager.StartListening("BubblePop", Pop);
        EventManager.StartListening("MouthClose", MouthSound);
        EventManager.StartListening("HandsScream", Hands);
    }

    public void SoundsGo ()
    {
        playSource.PlayOneShot(bubbleFizz);
        playSource.clip = sizzle;
        playSource.Play();

        normalSource.volume = 0;
        muffledSource.volume = 1;
    }

    public void SoundStop()
    {
        playSource.Stop();
        playSource.PlayOneShot(bubbleFizz);

        normalSource.volume = 1;
        muffledSource.volume = 0;
    }

    public void Splat ()
    {
        playSource.PlayOneShot(splat);
    }

    public void Pop ()
    {
        playSource.PlayOneShot(pop);
    }

    public void MouthSound ()
    {
        playSource.PlayOneShot(mouth);
    }

    public void Hands ()
    {
        if(scream)
        {
            scream = false;
            if (playSource.clip != hands)
            {
                playSource.clip = hands;
                playSource.Play();
            }
            else
            {
                playSource.volume = 1;
            }
        }
        else
        {
            scream = true;
            playSource.volume = 0;
        }
    }
}
