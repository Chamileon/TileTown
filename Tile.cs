using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tile
{

    public Tile(int X, int Y, bool Walkable = false, int Level = 8, bool Contructable = false, bool HaveEffect = false) { properties = new TileProperties(X, Y, Walkable, Level, Contructable, HaveEffect);}
    private TileProperties properties;
    public TileProperties Properties { get => properties; set => properties = value; }
    public GameObject tileInstance;
    
}

[System.Serializable]
public  class TileProperties
{
    public int x, y, level;
    public bool walkable = false, constructable = false, haveEffect = false; 
    public TileProperties(int X, int Y, bool Walkable, int Level,bool Contructable, bool HaveEffect) 
    {
        x = X;
        y = Y;
        walkable = Walkable;
        constructable = Contructable;
        haveEffect = HaveEffect;
        level = Level;
    }
}