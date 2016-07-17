using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Actor))]
public class FiniteStateMachine : MonoBehaviour
{
    private Actor actor;
    private State lastState;
    private State currentState = Idle.Instance;
    private State defualtState;

    // Use this for initialization
    void Start() {
        actor = this.GetComponent<Actor>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute(actor);
    }

    public void ChangeState(State newState)
    {
        lastState = currentState;
        currentState.Exit(actor);
        newState.Enter(actor);
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