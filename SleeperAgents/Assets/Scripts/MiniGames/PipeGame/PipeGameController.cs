using UnityEngine;
using System.Collections;

public class PipeGameController : MonoBehaviour {
    [SerializeField]
    private GameObject _defaultTile;
    public GameObject DefaultTile { get { return _defaultTile; } }

    [SerializeField]
    private int _width;
    public int Width { get { return _width; } set { _width = value; } }

    public Tile this[int x, int y]
    {
        get
        {
            Tile toReturn = null;
            if(tiles==null)
            {

            }
            if ((x >= 0 && x < Width) && (y >= 0 && y < Height))
            {
                toReturn = tiles[x, y];
            }
            return toReturn;
        }
        private set
        {
            if ((x >= 0 && x < Width) && (y >= 0 && y < Height))
            {
                tiles[x, y] = value;
            }
        }
    }


    [SerializeField]
    private int _height;
    public int Height { get { return _height; } set { _height = value; } }



    [SerializeField]
    private string _levelData = "";
    public string LevelData { get; set; }

    private Tile start;
    private Tile fillingTile;
    private Tile end;
    private Tile[,] tiles;

    public Tile selectedTile;

	// Use this for initialization
	void Start () {

	}

	public void GenerateBasicTileForLevelEditors()
	{
        GameObject tileHolder = new GameObject();
        tileHolder.name = "TILE HOLDER, PLEASE IGNORE"; 
        tileHolder.gameObject.transform.parent = this.gameObject.transform; 
		tiles = new Tile[Width, Height];
		for(int i = 0; i < Width; i ++)
		{
			for(int j = 0; j < Height; j ++)
			{
				tiles[i,j] = ((GameObject) Instantiate(DefaultTile, new Vector3(i+(i*.05f), j + (j*.05f), 0.0f), Quaternion.identity)).GetComponent<Tile>();
                tiles[i, j].transform.parent = tileHolder.gameObject.transform;
                tiles[i, j].X = i;
                tiles[i, j].Y = j;
			}
		}
	}

    public void GenerateTilesArrayFromChildren()
    {
    }

    public void EraseCurrentBoard()
    {
        DestroyAllChildren(); 
        LevelData = "";
    }

    public void DestroyAllChildren()
    {
        int childCount = this.gameObject.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            DestroyImmediate(this.gameObject.transform.GetChild(0).gameObject);
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
