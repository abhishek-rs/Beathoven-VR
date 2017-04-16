using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpeaker : MonoBehaviour {
	Object[] myMusic;

 void Awake(){
        myMusic = Resources.LoadAll("Music",typeof(AudioClip));
        GetComponent<AudioSource>().clip = myMusic[ApplicationModel.currentSong] as AudioClip;
    }
    
    void Start()
    {
        
        GetComponent<AudioSource>().Play();
        Debug.Log(myMusic);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
