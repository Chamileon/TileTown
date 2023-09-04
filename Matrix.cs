using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu(menuName: "Matrix")]
[RequireComponent(typeof(MapGenerator))]
[RequireComponent(typeof(God))]
public class Matrix : MonoBehaviour {

    public static Matrix matrix;
    [SerializeField] private MapProperties mapProperties;
    private Chunk[,] chunks;
    public static Tile[,] tiles;
    public MapProperties MapProperties { get => mapProperties; private set { mapProperties = value; } }
    
    public void DeleteTiles()
    {
        foreach (var tile in tiles) 
        {
            if (tile.tileInstance != null) { Destroy(tile.tileInstance); }
            else Debug.Log("NO se destruyó nada :(");
        }
    }
    public void LoadSeed() 
    {
        MapGenerator.mapGenerator.seed = MapProperties.seed;
    }
    
    public  void SaveSeed() 
    {
        Debug.Log(MapProperties.seed);
        Debug.Log(MapGenerator.mapGenerator.seed);
        MapProperties.seed = MapGenerator.mapGenerator.seed;
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
    }
    private void Awake()
    {
        InitializeMe();
 
        
        /* 
            +Delete the next example
        */
        foreach(Chunk Chunkie in chunks) 
        {
            Debug.Log("ID: " + Chunkie.GetID().x + ", " + Chunkie.GetID().y);
            foreach (Tile tile in Chunkie.GetTilesFromChunk())
            {
                Debug.Log("x = " + tile.Properties.x + " , y = " + tile.Properties.y);
            }
        }
        
    }
}
