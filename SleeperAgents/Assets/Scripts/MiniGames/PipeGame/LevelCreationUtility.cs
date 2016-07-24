using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System;

public class LevelCreationUtility : MonoBehaviour {

    public PipeCollection _allPipes = new PipeCollection();

    private Dictionary<string, Pipe> _allPipesDictionary;

    private Pipe this[string s] {
        get {
            if(_allPipesDictionary==null)
            {
                CreateDictionary(); 
            }
            return _allPipesDictionary[s];
        }
    }

    private static LevelCreationUtility Instance;

    void Start()
    {
        Init(); 
    }

    void Reset()
    {
        Init();
    }

    private void Init()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            LevelCreationUtility.Instance = this;
#if !UNITY_EDITOR
            DontDestroyOnLoad(Instance);
#endif
        }
    }

    private void CreateDictionary()
    {
        if(_allPipesDictionary==null)
        {
            _allPipesDictionary = new Dictionary<string, Pipe>();
            for(int i=0; i < _allPipes.Pipes.Count;i++)
            {
                _allPipesDictionary.Add(_allPipes.Pipes[i].LevelKey, _allPipes.Pipes[i]); 
            }
            _allPipes = null; 
        }
    }



    public static void SaveLevelDataFromString(PipeGameController level)
    {
        // Generate String and set it
        level.LevelData = ConvertLevelToString(level);
        level.DestroyAllChildren();
    }

    public static void GenerateLevelFromString(PipeGameController level)
    {
        string levelData = level.LevelData;
        string[] dataPieces = levelData.Split('|'); 
        string[] levelDimensions = dataPieces[0].Split(','); 
        if(levelDimensions.Length>1)
        {
            level.Width = Int32.Parse(levelDimensions[0]);
            level.Height = Int32.Parse(levelDimensions[1]); 
        }
        level.GenerateBasicTileForLevelEditors(); 
        for(int i = 0; i < level.Width;i++)
        {
            for(int j =0; j<level.Height;j++)
            {
                string currentPipeKey = dataPieces[1 + (i + j)];
                Pipe appropriatePipe = Instance[currentPipeKey];
                Pipe NewPipe = (Instantiate(appropriatePipe, level[i, j].transform.position, appropriatePipe.transform.rotation) as GameObject).GetComponent<Pipe>();
                NewPipe.X = i;
                NewPipe.Y = j;
                level[i, j].TilePipe = NewPipe; 
            }
        }
    }

    public static string ConvertLevelToString(PipeGameController level)
    {
        // Write out grid size probably like x,y|
        // Then for x*y, write tile data... maybe have it be a type? or just impose a type
        // from openings? ...
        // 

        StringBuilder levelStringBuilder = new StringBuilder();
        levelStringBuilder.Append(string.Format("{0},{1}", level.Width,level.Height)); 
        for(int i=0; i < level.Width;i++)
        {
            for(int j =0; j < level.Height;j++)
            {
                levelStringBuilder.Append(string.Format("|{0}", level[i, j].TilePipe.LevelKey)); 
            }
        }

        return levelStringBuilder.ToString();
    }
}
