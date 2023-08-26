using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SeedProperties
{
    [SerializeField] [Range(1f, 100f)] public float seed;
    [SerializeField] [Range(1f, 1000f)] public float scale;
    [SerializeField] [Range(1f, 10f)] public float dimension4;
    [SerializeField] [Range(0.1f, 1f)] public float dimension5;
    [SerializeField] [Range(1f, 2f)] public float dimension6;
}
