using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teeth : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Acid"))
        {
            Destroy(gameObject);
        }
    }
}
