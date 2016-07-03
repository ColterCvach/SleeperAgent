using UnityEngine;
using System.Collections;

public class SleeperAgent : MonoBehaviour {
    private FiniteStateMachine FSM;
    private Mover mover;


	// Use this for initialization
	void Start () {
        mover = this.GetComponent<Mover>();
        FSM = this.GetComponent<FiniteStateMachine>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                mover.destination = hit.point;
            }
            FSM.ChangeState(MoveToLocation.Instance);
        }
	}
}
