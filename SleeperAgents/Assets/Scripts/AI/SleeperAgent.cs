using UnityEngine;
using System.Collections;

public class SleeperAgent : Actor {
    private Mover mover;
    private Attacker attacker;
    private Suspect suspect;

	// Use this for initialization
	void Awake () {
        mover = this.GetComponent<Mover>();
        FSM = this.GetComponent<FiniteStateMachine>();
        attacker = this.GetComponent<Attacker>();
        suspect = this.GetComponent<Suspect>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
				mover.SetDestination(hit.point);
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
        if (attacker.weaponDrawn)
        {
            suspect.suspicionLevel = attacker.weapon.suspicionModifyer;
        }
        else
        {
            suspect.suspicionLevel = 0;
        }
    }
}
