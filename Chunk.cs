using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    private Vector2 ID;
    private int x, y;
    private Tile[,] tiles;
    public Chunk(int n, int m) 
    {
        x = 10;  
        y = 10;
        tiles = new Tile[x, y];
        ID = new Vector2(n , m); 
        for(int i = 0; i < x; i++) 
        {
            for(int j = 0; j < y; j++) 
            {
                tiles[i, j] = new Tile( i + ((int)ID.x * x), j + ((int)ID.y * y), false, false, false);
            }
        }
    }
    public Vector2 GetID { get { return ID; } }
    public int X { get { return x; } }
    public int Y { get { return y; } }  

    public Tile GetTileByIndex(int X, int Y) {return tiles[X, Y];}

    public Tile[,] GetTilesFromChunk() { return tiles; }

}
