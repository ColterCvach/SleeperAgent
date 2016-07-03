using UnityEngine;
using System.Collections;
using System;

public class Idle : State {
    private static Idle _instance;

    public static Idle Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Idle();
            }
            return _instance;
        }
    }

    private Idle() { }

    public void Enter(GameObject target) {}

    public void Execute(GameObject target) {}

    public void Exit(GameObject target) {}
}
