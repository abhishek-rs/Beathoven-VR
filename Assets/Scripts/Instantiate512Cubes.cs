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

			MeshRenderer m =_instanceSampleCube.AddComponent<MeshRenderer>() as MeshRenderer;
			m.enabled = true;

			this.transform.eulerAngles = new Vector3 (0, -5.625f * i, 0);
			_instanceSampleCube.transform.position = Vector3.forward * 100;
			_sampleCube [i] = _instanceSampleCube;

			// change color based on Spotify data (to fix, renderer not working)

			_sampleCube[i].GetComponent<Renderer> ().material.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time, 1));

		}
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 64; i++) {

			if (_sampleCube != null) {

				if(ApplicationModel.songs[ApplicationModel.currentSong, 0] == 1.00){
					_sampleCube[i].transform.GetChild(0).GetComponent<Renderer>().material.color = Color.Lerp( new Color( 1.0f, 0.549f, 0.0f, 1.0f), Color.yellow, Mathf.PingPong(Time.time, 1));
				}
				else{
					_sampleCube[i].transform.GetChild(0).GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time, 1));
				}

				_sampleCube [i].transform.localScale = new Vector3 (10, (AudioSpeaker._samples [i] * _maxScale) + 2, 10);
			}
		}
	}
}