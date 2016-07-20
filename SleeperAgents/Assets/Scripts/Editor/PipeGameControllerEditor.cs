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

		// if(GUILayout.Button("Reset"))
		// {
		// 	_mapBuilder.ReMakeSquares();
		// }
		// if(GUILayout.Button("Randomize Spawner Seeds"))
		// {
		// 	_mapBuilder.RandomizeAllSpanwerSeeds(); 
		// }

		if (GUILayout.Button ("Create Board")) {
			Debug.Log ("Create Board"); 
		}
	}
}
