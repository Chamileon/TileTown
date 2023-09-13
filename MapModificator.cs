using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpOrDown{ Up, Down, Change}
public static class MapModificator 
{
    public static void ModifyTile(UpOrDown ud) 
    {
        if(ud == UpOrDown.Up) 
        { 
            Tile t = SelectTile();
            //t.tileInstance = 
        }
        else if(ud == UpOrDown.Down) { }
    }
    public static void ConstructTile()
    {

    }

    public static Tile SelectTile() 
    {
        int x, y;
        x = Mathf.FloorToInt(WorldPosition().x);
        y = Mathf.FloorToInt(WorldPosition().y);
        Debug.Log("Log : " + Matrix.matrix.GetTileFromID(x, y).Properties.x + " en X, " + Matrix.matrix.GetTileFromID(x, y).Properties.y + " en Y.");
        return Matrix.matrix.GetTileFromID(x, y);
    }
    public static Vector3 WorldPosition() 
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return position;
    }
    public static bool IsWalkable(Tile t) { return t.Properties.walkable; }
    public static bool IsConstructable(Tile t) { return t.Properties.constructable; }
    public static bool HaveEffect(Tile t) { return t.Properties.haveEffect; }
     
}
