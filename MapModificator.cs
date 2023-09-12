using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapModificator 
{
    public static void ModifyMap() 
    {
        int x, y;
        x = Mathf.FloorToInt(WorldPosition().x);
        y = Mathf.FloorToInt(WorldPosition().y);
        Debug.Log("Log : " + Matrix.matrix.GetTileFromID(x, y).Properties.x + " en X, " + Matrix.matrix.GetTileFromID(x, y).Properties.y + " en Y.");
    }
    public static Vector3 WorldPosition() 
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return position;
    }
     
}
