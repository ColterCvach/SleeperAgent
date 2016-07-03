using UnityEngine;
using System.Collections;

public interface State
{
    void Enter(GameObject target);
    void Execute(GameObject target);
    void Exit(GameObject target);
}
