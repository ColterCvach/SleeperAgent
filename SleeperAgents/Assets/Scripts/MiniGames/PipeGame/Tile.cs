using UnityEngine;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	
    public bool locked = false;
    public float fillLevel = 0.0f;
    [SerializeField] private Pipe _pipe;
    public Pipe TilePipe { get { return _pipe; } set { _pipe = value; } }

    public bool IsLocked { get { return locked; } }
}