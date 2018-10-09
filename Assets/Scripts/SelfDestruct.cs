using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Acid") || other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }

    }
}
