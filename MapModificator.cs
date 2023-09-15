using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpOrDown{ None, Up, Down, Change}
public static class MapModificator 
{
    public static int ModifyTile(UpOrDown ud, int changelvl, int biomaNumber) 
    {
        if(ud == UpOrDown.Up) 
        { 
            Tile t = SelectTile();
            
            t.tileInstance.GetComponent<SpriteRenderer>().color = TileSet.tileset.GetBioma(biomaNumber).GetTileColorByLevel(CalculateNextLevel(t.Properties.level, UpOrDown.Up));
            t.Properties.level++;
            return t.Properties.level;
            
        }
        else if(ud == UpOrDown.Down) 
        {
            Tile t = SelectTile();
            t.tileInstance.GetComponent<SpriteRenderer>().color = TileSet.tileset.GetBioma(biomaNumber).GetTileColorByLevel(CalculateNextLevel(t.Properties.level,UpOrDown.Down));
            t.Properties.level--;
            return t.Properties.level;
        }
        else 
        {
            Tile t = SelectTile();
            t.Properties.level = changelvl;
            t.tileInstance.GetComponent<SpriteRenderer>().color = TileSet.tileset.GetBioma(biomaNumber).GetTileColorByLevel(changelvl);
            return t.Properties.level;
        }

    }
    private static int CalculateNextLevel(int actualLvl, UpOrDown ud) 
    {

        switch(ud)
        {
            case UpOrDown.Up: if(actualLvl < 9) { actualLvl++ ; } else { Debug.Log(actualLvl + " did not change"); } return actualLvl;
            case UpOrDown.Down: if (actualLvl > 0) { actualLvl--; } else { Debug.Log(actualLvl + " did not change"); } return actualLvl;
            default: Debug.Log("default!!"); return actualLvl;
        }


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
        Debug.Log(Matrix.matrix.GetTileFromID(x, y).Properties.level + " Is the lvl of tile");
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
