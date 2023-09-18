using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MapFile 
{ 
    public int Bioma;
    public int[,] levelOfTile = new int[500, 500];
    public bool[,] walkable = new bool[500, 500];
    public bool[,] constructable = new bool[500, 500];
    public bool[,] haveEffect = new bool[500, 500];
    public MapFile() { }
    public void Add(int x, int y, int level, bool w, bool c, bool h) 
    {
        levelOfTile[x, y] = level;
        walkable[x, y] = w;
        constructable[x, y] = c;
        haveEffect[x, y] = h;
    }
    
}
