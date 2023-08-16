using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour {

    public MapProperties propertiesOfMap;
    public Chunk[,] Chunks;

    public Chunk GetChunkFromID(int X, int Y) { return Chunks[X, Y]; }
    public void InitializeMe() 
    {
        Chunks = new Chunk[propertiesOfMap.x, propertiesOfMap.y];
        for (int i = 0; i < propertiesOfMap.x; i++)
        {
            for (int j = 0; j < propertiesOfMap.y; j++)
            {
                Chunks[i, j] = new Chunk(i, j);
            }
        }
    }
    private void Start()
    {
        InitializeMe();
 
        
        /* 
            +Delete the next example
        */
        foreach(Chunk Chunkie in Chunks) 
        {
            Debug.Log("ID: " + Chunkie.GetID.x + ", " + Chunkie.GetID.y);
            foreach (Tile tile in Chunkie.GetTilesFromChunk())
            {
                Debug.Log("x = " + tile.Properties.x + " , y = " + tile.Properties.y);
            }
        }
        
    }
}
