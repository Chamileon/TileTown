using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public static God god;
    public static readonly int ChunkMagnitude = 10;
    private void OnEnable()
    {
        if (god == null) { god = this; } else { Destroy(gameObject); }    
    }
    public static God GetGod { get { return god; } }
    private static Matrix mapMatrix;
    private void Awake()
    {
        mapMatrix = GetComponent<Matrix>();
    }
    public Matrix GetMatrix { get { return mapMatrix; } }  
}
