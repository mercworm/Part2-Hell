using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour {

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag("Tooth"))
        {
            StartCoroutine(Pop());
        }

        if(other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Pop ()
    {
        //play pop particle effect
        var rend = GetComponent<SpriteRenderer>();
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

    public void ToTheBeat ()
    {
        //triggers animation doing the pulsating
    }
}
