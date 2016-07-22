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

	}

	public void GenerateBasicTiles()
	{
        GameObject tileHolder = new GameObject();
        tileHolder.name = "TILE HOLDER, PLEASE IGNORE"; 
        tileHolder.gameObject.transform.parent = this.gameObject.transform; 
		tiles = new GameObject[Width, Height];
		for(int i = 0; i < Width; i ++)
		{
			for(int j = 0; j < Height; j ++)
			{
				tiles[i,j] = (GameObject) Instantiate(DefaultTile, new Vector3(i+(i*.05f), j + (j*.05f), 0.0f), Quaternion.identity);
                tiles[i, j].transform.parent = tileHolder.gameObject.transform;
			}
		}
	}

    public void EraseCurrentBoard()
    {
        int childCount = this.gameObject.transform.childCount;

        for(int i=0; i < childCount;i++)
        {
            DestroyImmediate(this.gameObject.transform.GetChild(0).gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
