using UnityEngine;
using System.Collections.Generic;

public class Guarder : MonoBehaviour {

    [SerializeField]
    private float _detectionThreshhold;
    public float DetectionThreshold { get { return _detectionThreshhold; } }

    [SerializeField]
    private List<Suspect> _suspects = new List<Suspect>();
    public List<Suspect> Suspects { get { return _suspects; } }

}
