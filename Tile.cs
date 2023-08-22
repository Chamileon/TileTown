using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tile
{

    public Tile(int X, int Y, bool Walkable, bool Contructable, bool HaveEffect) { properties = new TileProperties(X, Y, Walkable, Contructable, HaveEffect);}
    private TileProperties properties;
    public TileProperties Properties { get => properties; set => properties = value; }
    public Tile GetMe() { return this as Tile; }
    public GameObject tileInstance;
    public GameObject GetTileInWorld() { return tileInstance; }
}

[System.Serializable]
public  class TileProperties
{
    public int x, y, heigth;
    public bool walkable = false, constructable = false, haveEffect = false; 
    public TileProperties(int X, int Y, bool Walkable, bool Contructable, bool HaveEffect, int Heigth = 0) 
    {
        x = X;
        y = Y;
        walkable = Walkable;
        constructable = Contructable;
        haveEffect = HaveEffect;
        heigth = Heigth;
    }
}