using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Acid") || other.gameObject.CompareTag("KillZone") || other.gameObject.CompareTag("Heart"))
        {
            if(gameObject.tag == "Tooth")
            {
                StartCoroutine(ToothDeath());
            }
            else Destroy(gameObject);
        }
    }

    public ParticleSystem toothSystem;

    public IEnumerator ToothDeath ()
    {
        toothSystem.Play();
        var spriteRend = GetComponentInChildren<SpriteRenderer>();
        spriteRend.enabled = false;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
