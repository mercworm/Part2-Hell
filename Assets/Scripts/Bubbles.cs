using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour {

    public ParticleSystem popParticle;
    public Animator anim;

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
        anim.SetTrigger("HitPlayer");
        popParticle.Play();
        yield return new WaitForSeconds(0.2f);
        var rend = GetComponentInChildren<SpriteRenderer>();
        rend.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
