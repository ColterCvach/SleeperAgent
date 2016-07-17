using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
    public FiniteStateMachine FSM;

	// Use this for initialization
	void Start () {
        FSM = this.GetComponent<FiniteStateMachine>();
	}
}
