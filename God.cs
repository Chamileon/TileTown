using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public static God god;
    public static readonly int ChunkMagnitude = 10;
    [SerializeField] private bool _nextStepReady = false;
    public bool IsNextStepReady { get { return _nextStepReady; } set { _nextStepReady = value; } }
    private void OnEnable()
    {
        if (god == null) { god = this; } else { Destroy(gameObject); }    
    } 
}
