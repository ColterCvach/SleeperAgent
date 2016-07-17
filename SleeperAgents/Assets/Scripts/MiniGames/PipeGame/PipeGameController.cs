using UnityEngine;
using System.Collections;

public class PipeGameController : MonoBehaviour {
    [SerializeField]
    private int _width;
    public int Width { get { return _width; } }
    [SerializeField]
    private int _height;
    public int Height { get { return _height; } }

    private Tile start;
    private Tile end;
    private Tile[,] tiles;

	// Use this for initialization
	void Start () {
        tiles = new Tile[Width + 2, Height + 2];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
