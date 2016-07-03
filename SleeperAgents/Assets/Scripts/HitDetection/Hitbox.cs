using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour {

	[SerializeField] private int _damage =5; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		other.GetComponent<Attackable> ().TakeDamage (_damage); 
	}
}
