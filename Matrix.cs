using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour {

    public static Matrix matrix;
    public static MapProperties propertiesOfMap;
    public static Chunk[,] Chunks;
    [SerializeField] private MapProperties map;
    private Chunk[,] chunks;
    

    public static Chunk GetChunkFromID(int X, int Y) { return Chunks[X, Y]; }

    private void Singleton()
    {
        if (matrix != null) { Destroy(gameObject); } else { matrix = this; }
    }
    public void InitializeMe() 
    {
        propertiesOfMap = map;
        chunks = new Chunk[propertiesOfMap.x, propertiesOfMap.y];
        for (int i = 0; i < propertiesOfMap.x; i++)
        {
            for (int j = 0; j < propertiesOfMap.y; j++)
            {
                chunks[i, j] = new Chunk(i, j);
            }
        }
        Chunks = chunks;
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
