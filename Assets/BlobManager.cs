using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobManager : MonoBehaviour {

    public float forceApplied;
    public bool left;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            var addForce = other.gameObject.GetComponent<Rigidbody2D>();
            if (left)
            {
                addForce.AddForce(new Vector2(forceApplied, 0), 0);
            }
            else
            {
                addForce.AddForce(new Vector2(-forceApplied, 0), 0);
            }
        }
    }
}
