using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthManager : MonoBehaviour {

    public GameObject mouthClosed, mouthOpen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            mouthClosed.SetActive(true);
            mouthOpen.SetActive(false);
        }
    }
}
