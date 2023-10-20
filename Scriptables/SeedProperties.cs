using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SeedProperties
{

    [SerializeField] [Range(1f, 100f)] public float seed;
    [SerializeField] [Range(25f, 1000f)] public float scale;
    [SerializeField] [Range(1f, 10f)] public float dimension4;
    [SerializeField] [Range(0.1f, 1f)] public float dimension5;
    [SerializeField] [Range(1f, 2f)] public float dimension6;

    public SeedProperties Clone()
    {
        return new SeedProperties(this);
    }
    public SeedProperties(SeedProperties properties) 
    {
        seed = properties.seed;
        scale = properties.scale;
        dimension4 = properties.dimension4; 
        dimension5 = properties.dimension5;
        dimension6 = properties.dimension6;
    }
    public SeedProperties() 
    {
    }
}
