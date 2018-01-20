using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer instance=null;
    public static AudioSource universalMusic=null;

	void Awake ()
	{
		Debug.Log("Music player awake"+GetInstanceID());
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance=this;
			GameObject.DontDestroyOnLoad(gameObject);
            universalMusic = gameObject.GetComponent<AudioSource>();
            universalMusic.mute = false;
		}
	}

	// Use this for initialization
	void Start ()
	{
		Debug.Log("Music player Started"+GetInstanceID());

	}
	
	// Update is called once per frame
	void Update () {
	}
}
