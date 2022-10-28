using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class videoPlayer : MonoBehaviour
{
    private VideoPlayer vp;

    

    void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (vp.isPlaying == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
