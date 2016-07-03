using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUIControls : MonoBehaviour {

	[SerializeField] private Text _moveSpeedText;

	[SerializeField] private SleeperAgent _currentAgent;

	void Start()
	{
		_moveSpeedText.text = string.Format("{0}",_currentAgent.CurrentSpeed ()); 
	}


	public void IncrementSpeed()
	{
		_currentAgent.IncreaseSpeed (); 
		_moveSpeedText.text = string.Format("{0}",_currentAgent.CurrentSpeed ()); 
	}

	public void PlayerAttack()
	{
		_currentAgent.Attack (); 
	}
}
