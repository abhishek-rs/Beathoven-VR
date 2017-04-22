using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

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

	/*	not tested yet, might work
		if(ApplicationModel.songs[currentSong, 2] > 0.70){
			// Assigns a material named "Assets/Resources/stormysky" to the object.
			Material stormySky = Resources.Load("stormysky", typeof(Material)) as Material;
			this.GetComponent.renderer.material = stormySky;
		}else{
		Material blueSky = Resources.Load("bluesky", typeof(Material)) as Material;
			this.GetComponent.renderer.material = blueSky;
		}*/

	// Update is called once per frame
	void Update () {

		 
	}
}

