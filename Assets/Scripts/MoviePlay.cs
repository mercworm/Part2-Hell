using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MoviePlay : MonoBehaviour {

    private VideoPlayer player;

    public double time;
    public double currentTime;

    private bool onlyOnce = true;

    public GameObject fadeIn;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        time = player.clip.length;
    }

    private void Update()
    {
        currentTime = player.time;
        if(currentTime >= time && onlyOnce)
        {
            onlyOnce = false;
            StartCoroutine(GameTime());
        }
    }

    public IEnumerator GameTime ()
    {
        Debug.Log("Video Over!");
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Scene");
    }
}
