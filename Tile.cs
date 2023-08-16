using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tile
{
    public Tile(int X, int Y, bool Walkable, bool Contructable, bool HaveEffect) { properties = new TileProperties(X, Y, Walkable, Contructable, HaveEffect);}
    private TileProperties properties;
    public TileProperties Properties { get => properties; set => properties = value; }
}

[System.Serializable]
public  class TileProperties
{
    public int x, y;
    public bool walkable = false, constructable = false, haveEffect = false; 
    public TileProperties(int X, int Y, bool Walkable, bool Contructable, bool HaveEffect) 
    {
        x = X;
        y = Y;
        walkable = Walkable;
        constructable = Contructable;
        haveEffect = HaveEffect;
    }
}