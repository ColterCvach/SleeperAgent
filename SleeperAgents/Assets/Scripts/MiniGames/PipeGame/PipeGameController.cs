using UnityEngine;
using System.Collections;

public class PipeGameController : MonoBehaviour {

    public PipeCollection _allPipes = new PipeCollection();




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
                GenerateTilesArrayFromChildren(); 
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
    public string LevelData { get { return _levelData; } set { _levelData = value; } }

    private Tile start;
    private Tile fillingTile;
    private Tile end;
    private Tile[,] tiles;

    public Tile selectedTile;
    private GameObject tileHolder;
	// Use this for initialization
	void Start () {

	}

	public void GenerateBasicTileForLevelEditors()
	{
        tileHolder = new GameObject();
        tileHolder.name = "TILE HOLDER, PLEASE IGNORE"; 
        tileHolder.gameObject.transform.parent = this.gameObject.transform;
        Debug.Log("Generating all tiles"); 
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
        tiles = new Tile[Width, Height];

        for (int i =0; i < Width;i++)
        {
            for(int j =0; j < Height; j++)
            {
                tiles[i, j] = tileHolder.transform.GetChild((i * Width) + j).gameObject.GetComponent<Tile>(); 
            }
        }
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

    public Pipe GetPipeByKey(string key)
    {
        Pipe ret = null;
        bool found = false; 
        for(int i= 0; i < _allPipes.Pipes.Count && !found;i++)
        {
            if(_allPipes.Pipes[i].LevelKey.Equals(key))
            {
                found = true;
                ret = _allPipes.Pipes[i]; 
            }
        }

        return ret;
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
