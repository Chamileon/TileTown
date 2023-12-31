using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tile
{

    public Tile(int X, int Y, bool Walkable = false, int Level = 8, bool Contructable = false, bool HaveEffect = false) { properties = new TileProperties(X, Y, Walkable, Level, Contructable, HaveEffect);}
    private TileProperties properties;
    public TileProperties Properties { get => properties; set => properties = value; }
    public GameObject tileInstance;
    
    public GameObject onMe;
    
}

[System.Serializable]
public  class TileProperties
{
    public readonly int x, y;
    public int level;
    public bool walkable = false, constructable = false, haveEffect = false, occupied = false;
    public int objectType;//0 - creature; 1 - npc; 2 - structure; 3 - warp;
    public int objectID;// index to find in 0 - zoo; 1 - city; 2 - contructions; 4 - gameEvent
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