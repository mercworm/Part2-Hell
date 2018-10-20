using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSounds : MonoBehaviour {

    public AudioSource playSource, normalSource, muffledSource;
    public AudioClip bubbleFizz, sizzle, splat, pop, mouth;

    private void OnEnable()
    {
        EventManager.StartListening("InAcid", SoundsGo);
        EventManager.StartListening("OutAcid", SoundStop);
        EventManager.StartListening("SplatSound", Splat);
        EventManager.StartListening("BubblePop", Pop);
        EventManager.StartListening("MouthClose", MouthSound);
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
}
