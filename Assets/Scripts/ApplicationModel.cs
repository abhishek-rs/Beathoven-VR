using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModel {

	static public int currentSong = 0;
	static public double [,] songs = new double [4,5]{ 
								//mode, valence, energy, positivity, negativity 
    							{1.00, 0.529, 0.756, 0.068, 0.115}, 			//Sound of silence 
    							{1.00, 0.930, 0.715, 0.193, 0.0}, 			//One Love  
    							{1.00, 0.529, 0.456, 0.068, 0.115},
    							{1.00, 0.529, 0.456, 0.068, 0.115},				//Children of the grave 
    							};

	public static void setCurrentSong(int i){
		currentSong = i;
	}

}
