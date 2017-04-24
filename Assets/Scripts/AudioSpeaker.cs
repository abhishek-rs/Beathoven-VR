using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]

public class AudioSpeaker : MonoBehaviour {
	//Object[] myMusic;
	AudioSource _audioSource;
	public static float[] _samples = new float[512]; 
	public static float[] _frequencyBand = new float[8];
	public static float[] _bandBuffer = new float[8];
	float[] _bufferDecrease = new float[8];

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
		makeFrequBands ();
		bandBuffer ();
		
	}

	void bandBuffer(){
		for (int g = 0; g < 8; g++) {
			if (_frequencyBand [g] > _bandBuffer [g]) {
				_bandBuffer [g] = _frequencyBand [g];
				_bufferDecrease[g] = 0.005f;
			}

			if (_frequencyBand [g] < _bandBuffer [g]) {
				_bandBuffer [g] -= _bufferDecrease [g];
				_bufferDecrease[g] = 1.2f;
			}
		}
	}

	void getSpectrumAudioSource(){
		_audioSource.GetSpectrumData (_samples, 0, FFTWindow.Blackman);
	}

	void makeFrequBands(){

		int count = 0;

		for (int i = 0; i < 8; i++) {

			float average = 0;
			int sampCount = (int)Mathf.Pow (2, i) * 2;

			if (i == 7) {
				sampCount += 2;
			}

			for (int j = 0; j < sampCount; j++) {
				average += _samples [count] * (count + 1);
				count++;
			}

			average /= count;

			_frequencyBand [i] = average * 10;
		}
	
	}
}
