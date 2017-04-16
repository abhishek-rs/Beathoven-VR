using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songchange : MonoBehaviour {

	public void changeSong(int i){
		ApplicationModel.setCurrentSong(i);
	}

}
