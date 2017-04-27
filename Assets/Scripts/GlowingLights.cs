using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingLights : MonoBehaviour {

	Light light;

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
		average = (sumCount / 64) * 70;

		light.intensity = average;
		
	}
}
