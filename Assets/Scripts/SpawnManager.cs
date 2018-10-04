using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public ObjectTypes bubble;
    public ObjectTypes[] eye;

    public Transform eyeSpawnPointLeft, eyeSpawnPointRight;

    public void SpawnStart()
    {
        //To spawn more different types, just add another invoke repeating, then add another corresponding void.
        InvokeRepeating("BubbleSpawn", 0f, Random.Range(bubble.minTime, bubble.maxTime));

        InvokeRepeating("EyeSpawn", 0f, Random.Range(eye[0].minTime, eye[0].maxTime));
    }

    public void BubbleSpawn ()
    {
        //These both needs to be figured out when we have the screen done.
        var x = Random.Range(-3,3);
        var y = 47.2f;

        Vector3 spawn = new Vector3(x, y, 0f);
        
        Instantiate(bubble.objectPrefab[0], spawn, Quaternion.identity);

        InvokeRepeating("BubbleSpawn", Random.Range(2, 5), Random.Range(bubble.minTime, bubble.maxTime));
    }

    //Ok, so first we have to randomize if it's going to spawn a left or right eye.
    //Then we randomize color.
    //Then we spawn it on either the left or right wall, depending on the rotation.
    public void EyeSpawn ()
    {
        var eyeRotation = Random.Range(0, eye.Length);
        var randomEye = Random.Range(0, eye[eyeRotation].objectPrefab.Length);
        
        if(eye[eyeRotation].left)
        {
            Instantiate(eye[eyeRotation].objectPrefab[randomEye], eyeSpawnPointLeft);
        }
        else
        {
            Instantiate(eye[eyeRotation].objectPrefab[randomEye], eyeSpawnPointRight);
        }
    }
}
