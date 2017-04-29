using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modeChange : MonoBehaviour {

	// Use this for initialization
	public void changeMode(int i){
		ApplicationModel.setCurrentMode(i);
	}
}
