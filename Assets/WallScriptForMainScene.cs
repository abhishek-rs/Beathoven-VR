using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScriptForMainScene : MonoBehaviour {

	public Texture[] textures;
	int currentSong = ApplicationModel.currentSong;

	// Use this for initialization
	void Start () {
		if (textures.Length == 0)
            return;
         else if(ApplicationModel.songs[this.currentSong, 2] > 0.70)
		//	this.GetComponent<Renderer>().material.color = Color.black;
			this.GetComponent<Renderer>().material.mainTexture = textures[0];
		else
			this.GetComponent<Renderer>().material.mainTexture = textures[1];

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
