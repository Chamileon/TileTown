using System.Collections;
using System.Collections.Generic;

public class MapFile 
{ 
    public int Bioma;
    public int[,] levelOfTile = new int[100, 100];
    public MapFile() { }
    public void AddLevel(int newLevel, int x, int y) 
    {
        levelOfTile[x, y] = newLevel;
    }

}
