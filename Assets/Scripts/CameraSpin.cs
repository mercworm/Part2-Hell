using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpin : MonoBehaviour
{
    public GameObject player, cameraObj;
    public bool rotation = false;

    public static float spinTime;

    public float degreesPerSecond;

    private void Update()
    {
        if (rotation)
        {
            //Rotates the player. 
            player.transform.Rotate(Vector3.forward * degreesPerSecond * Time.deltaTime);
            cameraObj.transform.Rotate(Vector3.forward * degreesPerSecond * Time.deltaTime);
        }
    }

    public void StartSpin ()
    {
        StartCoroutine(Spin());
    }

    //Corutine that triggers the spin.
    //This should be able to be used both ways. 
    public IEnumerator Spin ()
    {
        //Trigger animation that fades in vignette image. 
        yield return new WaitForSeconds (2); //until the animation is done.
        rotation = true;
        yield return new WaitForSeconds (spinTime);
        StopSpin();
        //Trigger animation that fades out vignette image. 
    }

    //Stops the rotation.
    public void StopSpin ()
    {
        rotation = false;
    }
}

