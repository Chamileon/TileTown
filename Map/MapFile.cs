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
    public bool[,] occuppied = new bool[500, 500];
    public int[,] objectType= new int[500, 500];//0 - creature; 1 - npc; 2 - structure; 3 - warp;
    public int[,] objectID = new int[500, 500];// index to find in 0 - zoo; 1 - city; 2 - contructions; 4 - gameEvent
    public MapFile() { }
    public void Add(int x, int y, int level, bool w, bool c, bool h, bool oc = false, int obtype = 0, int obID = 0) 
    {
        levelOfTile[x, y] = level;
        walkable[x, y] = w;
        constructable[x, y] = c;
        haveEffect[x, y] = h;
        occuppied[x, y] = oc;
        if (oc) 
        {
            objectType[x, y] = obtype;
            objectID[x, y] = obID;
        }
        
    }
    
}
