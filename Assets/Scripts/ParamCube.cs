using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {

	public int _band;
	public float _startScale, _scaleMultiplier;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (_useBuffer) {
			//float vel = 0.9f;
			//float newY = Mathf.Lerp(_startScale, (AudioSpeaker._bandBuffer [_band] * _scaleMultiplier) + _startScale, 0.5f * 0.5f);
			//float newY = Mathf.SmoothDamp(1, (AudioSpeaker._bandBuffer [_band] * _scaleMultiplier) + _startScale, ref vel, 0.5f);
		transform.localScale = new Vector3 (transform.localScale.x, (AudioSpeaker._bandBuffer [_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
		//}

		//if (!_useBuffer) {
		//	transform.localScale = new Vector3 (transform.localScale.x, (AudioSpeaker._frequencyBand [_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
		//}
	}
}
