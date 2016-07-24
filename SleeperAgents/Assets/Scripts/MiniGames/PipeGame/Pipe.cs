using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pipe : MonoBehaviour {

    public int X { get { return _x; } set { _x = value; } }
    public int Y { get { return _y; } set { _y = value; } }
    public float FillRate { get { return _fillRate; } set { _fillRate = value; } }


    [SerializeField] private int _x;
    [SerializeField] private int _y;
    [SerializeField] private float _fillRate = 0.1f;
    [SerializeField] private string _levelKey = "";
    public string LevelKey { get { return _levelKey; } set { _levelKey = value; } }

    [SerializeField] private List<Directions> _openings = new List<Directions>();

    // public Tile[] neighbors = new Tile[Directions.GetNames(typeof(Directions)).Length];
    // public bool[] openDirections = new bool[Directions.GetNames(typeof(Directions)).Length];
    // 

    public bool isConnected = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
