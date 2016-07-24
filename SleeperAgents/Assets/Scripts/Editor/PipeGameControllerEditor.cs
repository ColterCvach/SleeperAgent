using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PipeGameController))]
public class PipeGameControllerEditor : Editor {

	private  PipeGameController _pipeGameController;

	void OnEnable()
	{

		_pipeGameController = (PipeGameController)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button ("Create New Board")) {
            _pipeGameController.EraseCurrentBoard(); 
			_pipeGameController.GenerateBasicTileForLevelEditors ();
		}
        if(GUILayout.Button("Load Level"))
        {

        }
        if(GUILayout.Button("Save Level"))
        {
            LevelCreationUtility.SaveLevelDataFromString(_pipeGameController); 
        }
	}
}
