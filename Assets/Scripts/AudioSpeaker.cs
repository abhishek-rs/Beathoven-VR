using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]

public class AudioSpeaker : MonoBehaviour {
	//Object[] myMusic;
	AudioSource _audioSource;
	public static float[] _samples = new float[512]; 

 	//void Awake(){
    //    myMusic = Resources.LoadAll("Music",typeof(AudioClip));
    //    GetComponent<AudioSource>().clip = myMusic[ApplicationModel.currentSong] as AudioClip;
    //}
    
    void Start()
    {
		_audioSource = GetComponent<AudioSource> ();
        //GetComponent<AudioSource>().Play();
        //Debug.Log(myMusic);
    }
		
	// Update is called once per frame
	void Update () {
		getSpectrumAudioSource ();
		
	}

	void getSpectrumAudioSource(){
		_audioSource.GetSpectrumData (_samples, 0, FFTWindow.Blackman);
	}
}
