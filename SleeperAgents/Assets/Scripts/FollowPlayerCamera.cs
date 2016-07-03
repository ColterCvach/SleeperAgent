using UnityEngine;
using System.Collections;

public class FollowPlayerCamera : MonoBehaviour {

	[SerializeField] private GameObject _followTarget; 

	private Vector3 _startingOffset = new Vector3(); 
	// Use this for initialization
	void Start () {
		_startingOffset = this.gameObject.transform.position; 
	}

	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = _followTarget.transform.position + _startingOffset; 
		this.gameObject.transform.position = targetPosition; 
	}
}
