using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public static God god;
    private void OnEnable()
    {
        god = this;
    }
    public static God GetGod { get { return god; } }
    private static Matrix mapMatrix;
    private void Awake()
    {
        mapMatrix = GetComponent<Matrix>();
    }
    public Matrix GetMatrix { get { return mapMatrix; } }  
}
