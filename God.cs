using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public static God god;
    public static readonly int ChunkMagnitude = 10;
    [Range(0,1f)]
    public static readonly float TileLevelMax = 1f;
    private void OnEnable()
    {
        if (god == null) { god = this; } else { Destroy(gameObject); }    
    } 
}
