using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable][CreateAssetMenu(menuName = "Create a Savefile of a Map", fileName = "New SaveMap")]
public class MapSave : ScriptableObject
{
    public int Bioma;
    public int[,] Levels = new int[1000,1000];
}
