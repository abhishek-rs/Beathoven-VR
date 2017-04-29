using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingLights : MonoBehaviour {

	Light light;
	int currentSong = ApplicationModel.currentSong;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {

		float average = 0.0f;
		float sumCount = 0.0f;

		for (int i = 0; i < 64; i++) {
			sumCount += AudioSpeaker._bandBuffer [i];
		}

		// float rand = Random.Range (10.0f, 100.0f);
		average = (sumCount / 64) * 350 * (float)ApplicationModel.songs [this.currentSong, 2];

		// change color based on Spotify data
		if (ApplicationModel.songs [this.currentSong, 2] > 0.50) {
			light.color = Color.red;
		} else if (ApplicationModel.songs [this.currentSong, 2] <= 0.50) {
			if (ApplicationModel.songs [this.currentSong, 1] > 0.20) {
				light.color = Color.cyan;	
			} else {
				light.color = Color.gray;	
			}
		}

		light.intensity = average;
	}
}
