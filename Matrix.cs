using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour {

    public static Matrix matrix;
    public static MapProperties map;
    public static Chunk[,] Chunks;
    [SerializeField] private MapProperties mapProperties;
    private Chunk[,] chunks;
    public static Tile[,] tiles;

    public static void SaveMap() 
    {
        map.seed = MapGenerator.seed;
    }
    
    public static Chunk GetChunkFromID(int X, int Y) { return Chunks[X, Y]; }
    public static Tile GetTileFromID(int X, int Y,int x, int y) 
    {
        return GetChunkFromID(X, Y).GetTileByIndex(x, y);
    }
    
    private void Singleton()
    {
        if (matrix != null) { Destroy(gameObject); } else { matrix = this; }
    }
    public void InitializeMe() 
    {
        map = mapProperties;
        chunks = new Chunk[map.X, map.Y];
        tiles = new Tile[map.ExtentionX,map.ExtentionY];
        for (int i = 0; i < map.X; i++)
        {
            for (int j = 0; j < map.Y; j++)
            {
                chunks[i, j] = new Chunk(i, j);
                for (int k = 0; k < chunks[i,j].X; k++) 
                {
                    for(int l = 0; l < chunks[i,j].Y; l++) 
                    {
                        tiles[(i * God.ChunkMagnitude) + k,(j * God.ChunkMagnitude) + l] = chunks[i,j].GetTileByIndex(k, l);
                        Debug.Log(tiles[(i * God.ChunkMagnitude) + k, (j * God.ChunkMagnitude) + l].Properties.x + " X & " + 
                            tiles[(i * God.ChunkMagnitude) + k, (j * God.ChunkMagnitude) + l].Properties.y + " Y ADDED TO TILES ");
                    }
                }
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
            Debug.Log("ID: " + Chunkie.GetID().x + ", " + Chunkie.GetID().y);
            foreach (Tile tile in Chunkie.GetTilesFromChunk())
            {
                Debug.Log("x = " + tile.Properties.x + " , y = " + tile.Properties.y);
            }
        }
        
    }
}
