using UnityEngine;
using System.Collections;

public class FiniteStateMachine : MonoBehaviour
{

    public State lastState;
    public State currentState;
    public State defualtState;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute(this.gameObject);
    }

    private void changeState(State newState)
    {
        lastState = currentState;
        currentState.Exit(this.gameObject);
        newState.Enter(this.gameObject);
        currentState = newState;
    }
}