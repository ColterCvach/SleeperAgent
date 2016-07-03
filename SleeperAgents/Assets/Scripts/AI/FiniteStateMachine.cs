using UnityEngine;
using System.Collections;

public class FiniteStateMachine : MonoBehaviour
{
    private State lastState;
    private State currentState = Idel.Instance;
    private State defualtState;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute(this.gameObject);
    }

    public void ChangeState(State newState)
    {
        lastState = currentState;
        currentState.Exit(this.gameObject);
        newState.Enter(this.gameObject);
        currentState = newState;
    }

    public void SetDefaultState(State defualtState)
    {
        this.defualtState = defualtState;
    }

    public void defualt()
    {
        ChangeState(defualtState);
    }

    public void Revert()
    {
        ChangeState(lastState);
    }
}