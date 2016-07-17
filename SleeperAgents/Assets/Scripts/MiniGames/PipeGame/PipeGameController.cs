using UnityEngine;
using System.Collections;

public class PipeGameController : MonoBehaviour {
    [SerializeField]
    private GameObject _defaultTile;
    public GameObject DefaultTile { get { return _defaultTile; } }

    [SerializeField]
    private int _width;
    public int Width { get { return _width; } }

    [SerializeField]
    private int _height;
    public int Height { get { return _height; } }

    private Tile start;
    private Tile fillingTile;
    private Tile end;
    private GameObject[,] tiles;

    public Tile selectedTile;

	// Use this for initialization
	void Start () {
        tiles = new GameObject[Width, Height];
        for(int i = 0; i < Width; i ++)
        {
            for(int j = 0; j < Height; j ++)
            {
                tiles[i,j] = (GameObject) Instantiate(DefaultTile, new Vector3(i, j, 0.0f), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
