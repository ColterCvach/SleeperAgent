using UnityEngine;
using System.Collections;
using System;

public class Idel : State {
    private static Idel _instance;

    public static Idel Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Idel();
            }
            return _instance;
        }
    }

    private Idel() { }

    public void Enter(GameObject target) {}

    public void Execute(GameObject target) {}

    public void Exit(GameObject target) {}
}
