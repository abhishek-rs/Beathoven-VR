using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowLight : MonoBehaviour {

	Renderer rend;
	public float _maxScale;

	int currentSong = ApplicationModel.currentSong;

	void Start() {
		// rend = GetComponent<Renderer>();
		// rend.material.shader = Shader.Find("Specular");

		// GameObject lightGameObject = new GameObject("The Light");
		Light light = GetComponent<Light>();
		light.color = Color.blue;
		//lightGameObject.transform.position = new Vector3(0, 5, 0);
	}

	void Update() {

		// Debug.Log ("sample: " + AudioSpeaker._samples [i] * _maxScale);
		for(int i = 0; i < 64; i++){
			light.color = new Color (Color.red, Color.red, Color.red, AudioSpeaker._samples [i] * _maxScale);
		}

		// change color intensity based on energy
		// if (ApplicationModel.songs [this.currentSong, 2] > 0.70) {
			// pick a random color
			// Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );

			// apply it on current object's material
			// rend.material.SetColor("_Color", Color.red);
		// }
	}
}
