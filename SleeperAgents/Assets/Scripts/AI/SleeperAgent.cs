using UnityEngine;
using System.Collections;

public class SleeperAgent : MonoBehaviour {
    private FiniteStateMachine FSM;
    private Mover mover;
    private Attacker attacker;

	// Use this for initialization
	void Awake () {
        mover = this.GetComponent<Mover>();
        FSM = this.GetComponent<FiniteStateMachine>();
        attacker = this.GetComponent<Attacker>();
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

	public void IncreaseSpeed()
	{
		mover.IncrementSpeed (); 
	}

	public int CurrentSpeed()
	{
		return mover.currentSelectedSpeed; 
	}

	public void Attack()
	{
		attacker.ToggleDrawnWeapon();
	}
}
