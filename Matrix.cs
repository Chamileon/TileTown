using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu(menuName: "Matrix")]
[RequireComponent(typeof(MapGenerator))]
[RequireComponent(typeof(God))]
public class Matrix : MonoBehaviour {

    public static Matrix matrix;
    public static Chunk[,] Chunks;
    [SerializeField] private MapProperties mapProperties;
    private Chunk[,] chunks;
    public static Tile[,] tiles;

    public MapProperties MapProperties { get => mapProperties; set { mapProperties = value; } }
    public  void SaveMap() 
    {
        mapProperties.Seed = MapGenerator.mapGenerator.Seed;
        
    }
    public void DeleteTiles()
    {
        foreach (var tile in tiles) 
        {
            if (tile.tileInstance != null) { Destroy(tile.tileInstance); }
        }
    }
    public void LoadSeed() 
    {
        Debug.Log(MapProperties.Seed + " Loaded Seed");
        SeedProperties properties = MapProperties.Seed.Clone();
        MapGenerator.mapGenerator.Seed = properties;
        
        

    }

    public  void SaveSeed() 
    {
        Debug.Log(MapProperties.Seed + " Saved Seed");
        SeedProperties properties = MapGenerator.mapGenerator.Seed.Clone();
        mapProperties.Seed = properties;
    }
    public Chunk GetChunkFromID(int X, int Y) { return chunks[X, Y]; }
    public Tile GetTileFromID(int X, int Y,int x, int y) 
    {
        return GetChunkFromID(X, Y).GetTileByIndex(x, y);
    }
    public void InitializeMe() 
    {
        matrix = this;
        chunks = new Chunk[mapProperties.X, mapProperties.Y];
        tiles = new Tile[mapProperties.ExtentionX,mapProperties.ExtentionY];
        for (int i = 0; i < mapProperties.X; i++)
        {
            for (int j = 0; j < mapProperties.Y; j++)
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
    private void Awake()
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
