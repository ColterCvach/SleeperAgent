using UnityEngine;
using System.Collections;

public interface State
{
    void Enter(GameObject parent);
    void Execute(GameObject parent);
    void Exit(GameObject parent);
}
