using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowLight : MonoBehaviour {

	Renderer rend;
	public float _maxScale;

	int currentSong = ApplicationModel.currentSong;

	void Start() {
		rend = GetComponent<Renderer>();
		//rend.material.shader = Shader.Find("Specular");
	}

	void Update() {

		Debug.Log ("energy value: " + ApplicationModel.songs [this.currentSong, 2]);

		// change color intensity based on energy
		if (ApplicationModel.songs [this.currentSong, 2] > 0.70) {
			// pick a random color
			// Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );

			// apply it on current object's material
			rend.material.SetColor("_Color", Color.red);
		}
	}
}
