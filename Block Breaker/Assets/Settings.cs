using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    public bool isPaused=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
            isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
		
	}

    public void MuteMusic()
    {
        MusicPlayer.universalMusic.mute = !MusicPlayer.universalMusic.mute;
    }

    public void Pause()
    {
        print("Button Clicked");
        isPaused = !isPaused;
        
        if(isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }
}
