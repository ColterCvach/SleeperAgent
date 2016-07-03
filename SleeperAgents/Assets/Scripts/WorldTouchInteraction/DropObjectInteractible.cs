using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class DropObjectInteractible : TouchInteractible {

	private Rigidbody _objectRigidbody;

	// Use this for initialization
	void Start () {
		_objectRigidbody = GetComponent<Rigidbody> (); 
	}

	public override void Activate ()
	{
		_objectRigidbody.useGravity = true; 
	}

}
