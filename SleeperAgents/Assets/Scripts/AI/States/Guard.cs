using UnityEngine;
using System.Collections.Generic;
using System;

public class Guard : State {

    private static Guard _instance;

    public static Guard Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Guard();
            }
            return _instance;
        }
    }

    private Guard() { }

    private Dictionary<GameObject, Guarder> guarders = new Dictionary<GameObject, Guarder>();
    private Dictionary<GameObject, Mover> Movers = new Dictionary<GameObject, Mover>();


    public void Enter(Actor target)
    {
    }

    public void Execute(Actor target)
    {
        Guarder guard = getGuarder(target.gameObject);
        int topSuspect = 0;
        float topSuspicionLevel = 0;
        for(int i = 0; i < guard.Suspects.Count; i++)
        {
            float distanceToSusupect = (guard.transform.position - guard.Suspects[i].transform.position).magnitude;
            float suspicionLevel = guard.Suspects[i].suspicionLevel / distanceToSusupect;
            if(suspicionLevel > topSuspicionLevel)
            {
                topSuspect = i;
                topSuspicionLevel = suspicionLevel;
            }
        }
        
        if(topSuspicionLevel >= guard.DetectionThreshold)
        {
            getMover(target.gameObject).destination = guard.Suspects[topSuspect].transform.position;
            target.FSM.ChangeState(Search.Instance);
        }
    }

    public void Exit(Actor target)
    {
    }

    private Guarder getGuarder(GameObject target)
    {
        Guarder targetGuarder = null;
        if (!guarders.TryGetValue(target, out targetGuarder))
        {
            targetGuarder = target.GetComponent<Guarder>();
            guarders.Add(target, targetGuarder);
        }
        return targetGuarder;
    }

    private Mover getMover(GameObject target)
    {
        Mover targetMover = null;
        if (!Movers.TryGetValue(target, out targetMover))
        {
            targetMover = target.GetComponent<Mover>();
            Movers.Add(target, targetMover);
        }
        return targetMover;
    }
}
