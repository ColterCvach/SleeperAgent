using UnityEngine;
using System.Collections;

public class TouchTracker : MonoBehaviour {

	[SerializeField] private LayerMask _layersWeCareAboutTouching;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit; 
			Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (r, out hit, 100f, _layersWeCareAboutTouching)) {
				ResolveTouch (hit);
			}
		}
	}

	void ResolveTouch(RaycastHit hit)
	{
		TouchInteractible touchedObject = hit.collider.GetComponent<TouchInteractible> ();
		touchedObject.Activate (); 
	}
}
