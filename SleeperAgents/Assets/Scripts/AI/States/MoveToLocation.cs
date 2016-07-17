using UnityEngine;
using System.Collections.Generic;
using System;

public class MoveToLocation : State
{
    private static MoveToLocation _instance;
    private Dictionary<GameObject, NavMeshAgent> navMesheAgents = new Dictionary<GameObject, NavMeshAgent>();
    private Dictionary<GameObject, Mover> destinations = new Dictionary<GameObject, Mover>();

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

    public void Enter(Actor target)
    {
        NavMeshAgent navMeshAgent = GetNavMeshAgent(target.gameObject);
        navMeshAgent.destination = GetMover(target.gameObject).destination;
    }

    public void Execute(Actor target)
    {
        if(target.transform.position == GetMover(target.gameObject).destination)
        {
           target.FSM.defualt();
        }
    }

    public void Exit(Actor target)
    {
        NavMeshAgent navMeshAgent = GetNavMeshAgent(target.gameObject);
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
}

