using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthManager : MonoBehaviour
{

    public GameObject mouthClosed, mouthOpen;

    public ParticleSystem closeParticles;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //These lines were made for another version of the mouth.
        //if(other.gameObject.CompareTag("Player"))
        //{
        //    mouthClosed.SetActive(true);
        //    mouthOpen.SetActive(false);
        //    var speed = GetComponent<ScrollingObject>();
        //    if (speed != null) speed.ChangeSpeed(4);
        //}

        if (other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }

    public void OpenMouth()
    {
        mouthClosed.SetActive(false);
        mouthOpen.SetActive(true);
        EventManager.TriggerEvent("ShakeOff");
    }

    public void CloseMouth()
    {
        mouthClosed.SetActive(true);
        mouthOpen.SetActive(false);

        //closeParticles.Play();
        //trigger a screenshake
        EventManager.TriggerEvent("ShakeOn");
        EventManager.TriggerEvent("MouthClose");
    }
}
