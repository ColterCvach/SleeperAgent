using UnityEngine;
using System.Collections;

public class Attackable : MonoBehaviour {

	[SerializeField] private int _health = 5;

	// Use this for initialization
	void Start () {
	
	}

	public void TakeDamage(int damage)
	{
		_health -= damage;
	}
}
