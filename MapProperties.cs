using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Map", fileName = "Map Mame")]

[System.Serializable]
public class MapProperties : ScriptableObject
{
    [Header("Extention")]
    public int x, y;
    [Header("Details")]
    public new string name;
    [TextArea(3, 20)]
    public string description;

}
