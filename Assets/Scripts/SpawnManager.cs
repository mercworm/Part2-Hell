using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public ObjectTypes bubble;

    public void SpawnStart()
    {
        //To spawn more different types, just add another invoke repeating, then add another corresponding void.
        InvokeRepeating("BubbleSpawn", 0f, Random.Range(bubble.minTime, bubble.maxTime));
    }

    public void BubbleSpawn ()
    {
        //These both needs to be figured out when we have the screen done.
        var x = Random.Range();
        var y = Random.Range();

        Vector3 spawn = new Vector3(x, y, 0f);

        Instantiate(bubble.objectPrefab, spawn, Quaternion.identity);

        InvokeRepeating("BubbleSpawn", Random.Range(2, 5), Random.Range(bubble.minTime, bubble.maxTime));
    }
}
