﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

	public float smoothTime = 0.5F;
    public float yVelocity = 0.0F;
    

	// Use this for initialization
	void Start () {
		
		int currentSong = ApplicationModel.currentSong;

		if(ApplicationModel.songs[currentSong, 2] > 0.70)
			this.GetComponent<Renderer>().material.color = Color.black;
		else
			this.GetComponent<Renderer>().material.color = new Color( 0.529f, 0.807f, 0.980f, 1.0f);
		}
	
	// Update is called once per frame
	void Update () {
		
	}
}
