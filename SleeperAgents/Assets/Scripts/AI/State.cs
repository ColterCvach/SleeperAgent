using UnityEngine;
using System.Collections;

public interface State
{
    void Enter(Actor target);
    void Execute(Actor target);
    void Exit(Actor target);
}
