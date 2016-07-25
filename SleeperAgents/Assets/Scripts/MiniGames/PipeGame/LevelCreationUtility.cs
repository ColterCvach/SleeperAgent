using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System;

public class LevelCreationUtility : MonoBehaviour {

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
                string currentPipeKey = dataPieces[1 + ((i*level.Width) + j)];
                if(!currentPipeKey.Equals("0"))
                {
                    Pipe appropriatePipe = level.GetPipeByKey(currentPipeKey);

                    if(appropriatePipe!=null)
                    {
                        Pipe newPipe = (Pipe)(Instantiate(appropriatePipe, level[i, j].transform.position, new Quaternion()));
                        if(newPipe!=null)
                        {
                            newPipe.X = i;
                            newPipe.Y = j;
                            level[i, j].TilePipe = newPipe;
                            newPipe.transform.parent = level[i, j].transform;
                        }
                        else
                        {
                            Debug.Log("HOW DID THIS HAPPEN"); 
                        }

                    }
                    else
                    {
                        Debug.LogWarning("Could not find pipe with key " + currentPipeKey); 
                    }

                }

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
                Pipe toWrite = level[i, j].TilePipe;
                string data = "0"; 
                if(toWrite!=null)
                {
                    data = toWrite.LevelKey;
                }
                levelStringBuilder.Append(string.Format("|{0}", data)); 
            }
        }
        return levelStringBuilder.ToString();
    }
}
