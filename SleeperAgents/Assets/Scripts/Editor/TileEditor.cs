using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Tile))]
[CanEditMultipleObjects]
public class TileEditor : Editor {

    public PipeCollection pipeCollection;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.BeginHorizontal();
        List<Pipe> _pipes = pipeCollection.Pipes;
        for (int i = 0; i < _pipes.Count; i++)
        {
            GameObject currentPipe = _pipes[i].gameObject;
            Texture2D meTexture = AssetPreview.GetAssetPreview(currentPipe);
            GUIStyle myStyle = new GUIStyle();
            myStyle.fixedWidth = 55f;
            myStyle.margin.right = 5;
            if (GUILayout.Button(meTexture, myStyle))
            {
                for (int j = 0; j < targets.Length; j++)
                {
                    var currentTile = ((Tile)targets[j]);
                    if (!currentTile.IsLocked)
                    {
                        if (currentTile.TilePipe != null)
                        {
                            DestroyImmediate(currentTile.TilePipe.gameObject);
                        }
                        var instantiatedPipe = ((GameObject)Instantiate(currentPipe, currentTile.transform.position, currentPipe.gameObject.transform.rotation)).GetComponent<Pipe>();
                        currentTile.TilePipe = instantiatedPipe;
                        instantiatedPipe.transform.parent = currentTile.gameObject.transform;
                    }
                }
            }
        }


    }


}
