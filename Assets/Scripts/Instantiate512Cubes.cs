using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour {

	public GameObject _sampleCubePrefab;
	GameObject[] _sampleCube = new GameObject[64];
	public float _maxScale;

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
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 64; i++) {
			if (_sampleCube != null) {
				// transform.localScale = new Vector3 (transform.localScale.x, (AudioSpeaker._bandBuffer [_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
				_sampleCube [i].transform.localScale = new Vector3 (10, (AudioSpeaker._bandBuffer [i] * _maxScale) + 2, 10);
			}
		}
	}
}
