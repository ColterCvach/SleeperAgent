using UnityEngine;
using System.Collections;
using System;

public class Search : State {

    private static Search _instance;

    public static Search Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Search();
            }
            return _instance;
        }
    }

    private Search() { }


    public void Enter(Actor target)
    {

    }

    public void Execute(Actor target)
    {
        
    }

    public void Exit(Actor target)
    {

    }
}
