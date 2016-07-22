using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeCollection : MonoBehaviour {
    [SerializeField] private List<Pipe> _pipes = new List<Pipe>();
    public List<Pipe> Pipes { get { return _pipes; } }
}
