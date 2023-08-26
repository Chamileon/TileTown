using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Map", fileName = "Map Mame")]

[System.Serializable]
public class MapProperties : ScriptableObject
{
    [Header("Extention")]
    [SerializeField] private int x, y;
    public int X { get { return x; } }
    public int Y { get { return y; } }
    public int ExtentionX { get { return x * 10; } }
    public int ExtentionY { get { return y * 10; } }
    [Header("Details")]
    public new string name;
    [TextArea(3, 20)]
    public string description;
    [Header("Seed")]
    [Range(1f, 100f)]
    [SerializeField] public SeedProperties seed;

    
}
