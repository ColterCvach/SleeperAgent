using UnityEngine;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
    public Tile[] neighbors = new Tile[Directions.GetNames(typeof(Directions)).Length];
    public bool[] openDirections = new bool[Directions.GetNames(typeof(Directions)).Length];
    public bool isConnected = false;
    public bool locked = false;
    public float fillLevel = 0.0f;
    public float fillRate = 0.1f;
    public Directions fillDirection;
}