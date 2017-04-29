using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModel {

	static public int currentSong = 0;
	static public double [,] songs = new double [4,5]{ 
								//mode, valence, energy, positivity, negativity 
    							{1.00, 0.429, 0.433, 0.049, 0.024}, 			// Bowie - Space Oddity 
    							{0.00, 0.179, 0.376, 0.172, 0.095}, 			// Beatles - Come together  
    							{1.00, 0.080, 0.976, 0.132, 0.018},				// ACDC - Let there be rock
    							{0.00, 0.232, 0.404, 0.108, 0.093},				// Queen - Bohemian rhapsody 
    							};

	public static void setCurrentSong(int i){
		currentSong = i;
	}

}
