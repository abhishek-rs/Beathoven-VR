using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour {

	public GameObject _sampleCubePrefab;
	GameObject[] _sampleCube = new GameObject[512];
	public float _maxScale;
	int currentSong = ApplicationModel.currentSong;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 64; i++) {
			GameObject _instanceSampleCube = (GameObject)Instantiate (_sampleCubePrefab);
			_instanceSampleCube.transform.position = this.transform.position;
			_instanceSampleCube.transform.parent = this.transform;
			_instanceSampleCube.name = "SampleCube " + i;

			this.transform.eulerAngles = new Vector3 (0, -5.625f * i, 0);
			_instanceSampleCube.transform.position = Vector3.forward * 100;
			_sampleCube [i] = _instanceSampleCube;

			// change color based on Spotify data (to fix, renderer not working)

			//if (ApplicationModel.songs [this.currentSong, 2] > 0.70) {
			//	_sampleCube[i].GetComponent<Renderer> ().material.color = Color.red;
			//} else if (ApplicationModel.songs [this.currentSong, 2] <= 0.70) {
			//	if (ApplicationModel.songs [this.currentSong, 1] > 0.50) {
			//		_sampleCube[i].GetComponent<Renderer> ().material.color = Color.cyan;	
			//	} else {
			//		_sampleCube[i].GetComponent<Renderer> ().material.color = Color.gray;	
			//	}
			//}
		}
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 64; i++) {
			if (_sampleCube != null) {
				_sampleCube [i].transform.localScale = new Vector3 (10, (AudioSpeaker._samples [i] * _maxScale) + 2, 10);
			}
		}
	}
}