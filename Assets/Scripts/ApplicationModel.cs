using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModel {

	static public int currentSong = 1;
	static public double [,] songs = new double [4,5]{ 
								//mode, valence, energy, positivity, negativity 
    							{1.00, 0.529, 0.456, 0.068, 0.115}, 			// Sound of silence 
    							{1.00, 0.390, 0.540, 0.347, 0.089}, 			// Beatles - Here comes the sun  
    							{1.00, 0.080, 0.976, 0.132, 0.018},				// ACDC - Let there be rock
    							{0.00, 0.232, 0.404, 0.108, 0.093},				// Queen - Bohemian rhapsody 
    							};

	public static void setCurrentSong(int i){
		currentSong = i;
	}

}
