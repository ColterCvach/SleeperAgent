using UnityEngine;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	
	// Why does a tile care about it's neighbors? shouldn't it just be a fill level, fill rate, x and y?
	// I think the 'neighbors' should be handled in the 'Pipe' class
	// Just have a list of directions they can flow so you can traverse them to check if they reach the end and do not leak

    public bool locked = false;
    public float fillLevel = 0.0f;


}