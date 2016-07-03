using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour {
    private NavMeshAgent navMeshAgent;
    public Vector3 destination;
    public int currentSelectedSpeed = 1;
    public float[] speeds = { 0.0f, 1.0f, 2.0f, 3.0f };

    // Use this for initialization
    void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeSelectedSpeed(int selectedSpeed)
    {
        if(!(selectedSpeed < 0 || selectedSpeed > 3))
        {
            currentSelectedSpeed = selectedSpeed;
            navMeshAgent.speed = currentSelectedSpeed;
        }
    }
}
