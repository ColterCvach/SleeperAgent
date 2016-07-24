using UnityEngine;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	
    public bool locked = false;
    public float fillLevel = 0.0f;
    [SerializeField] private int _x;
    [SerializeField] private int _y;

    public int X { get { return _x; } set { _x = value; } }
    public int Y { get { return _y; } set { _y = value; } }
    [SerializeField] private Pipe _pipe;
    public Pipe TilePipe { get { return _pipe; } set { _pipe = value; } }
    public bool IsLocked { get { return locked; } }
}