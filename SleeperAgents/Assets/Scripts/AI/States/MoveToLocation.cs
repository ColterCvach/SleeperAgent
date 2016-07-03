using UnityEngine;
using System.Collections.Generic;
using System;

public class MoveToLocation : State
{
    private static MoveToLocation _instance;
    private Dictionary<GameObject, NavMeshAgent> navMesheAgents = new Dictionary<GameObject, NavMeshAgent>();
    private Dictionary<GameObject, Mover> destinations = new Dictionary<GameObject, Mover>();
    private Dictionary<GameObject, FiniteStateMachine> FSMs = new Dictionary<GameObject, FiniteStateMachine>();

    public static MoveToLocation Instance
    { get
        {
            if(_instance == null)
            {
                _instance = new MoveToLocation();
            }
            return _instance;
        }
    }

    private MoveToLocation() { }

    public void Enter(GameObject target)
    {
        NavMeshAgent navMeshAgent = GetNavMeshAgent(target);
        navMeshAgent.destination = GetMover(target).destination;
    }

    public void Execute(GameObject target)
    {
        if(target.transform.position == GetMover(target).destination)
        {
            GetStatMachine(target).defualt();
        }
    }

    public void Exit(GameObject target)
    {
        NavMeshAgent navMeshAgent = GetNavMeshAgent(target);
        navMeshAgent.destination = target.transform.position;
    }

    private NavMeshAgent GetNavMeshAgent(GameObject target)
    {
        NavMeshAgent targetMeshAgent = null;
        if(!navMesheAgents.TryGetValue(target, out targetMeshAgent))
        {
            targetMeshAgent = target.GetComponent<NavMeshAgent>();
            navMesheAgents.Add(target, targetMeshAgent);
        }
        return targetMeshAgent;
    }

    private Mover GetMover(GameObject target)
    {
        Mover targetMover = null;
        if(!destinations.TryGetValue(target , out targetMover))
        {
            targetMover = target.GetComponent<Mover>();
            destinations.Add(target, targetMover);
        }
        return targetMover;
    }

    private FiniteStateMachine GetStatMachine(GameObject target)
    {
        FiniteStateMachine targetFSM = null;
        if (!FSMs.TryGetValue(target, out targetFSM))
        {
            targetFSM = target.GetComponent<FiniteStateMachine>();
            FSMs.Add(target, targetFSM);
        }
        return targetFSM;
    }
}

