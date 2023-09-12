using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu(menuName: "Matrix")]
[RequireComponent(typeof(MapGenerator))]
[RequireComponent(typeof(God))]
public class Matrix : MonoBehaviour {

    public static Matrix matrix;
    public static Chunk[,] Chunks;
    public static Tile[,] tiles;
    [SerializeField] private MapProperties mapProperties;
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
    public Chunk GetChunkFromID(int X, int Y) { return Chunks[X, Y]; }
    public Tile GetTileFromID(int indexXChunk, int indexYChunk,int indexTileX, int indexTileY)
    {
        return GetChunkFromID(indexXChunk, indexYChunk).GetTileByIndex(indexTileX, indexTileY);
    }
    public Tile GetTileFromID(int indexXTile,int indexYTile) { return tiles[indexXTile, indexYTile]; }
    IEnumerator InitializeMe() 
    {
        matrix = this;
        Chunks = new Chunk[mapProperties.X, mapProperties.Y];
        tiles = new Tile[mapProperties.ExtentionX,mapProperties.ExtentionY];
        for (int i = 0; i < mapProperties.X; i++)
        {
            yield return null;

            for (int j = 0; j < mapProperties.Y; j++)
            {
                Chunks[i, j] = new Chunk(i, j);
                for (int k = 0; k < Chunks[i,j].X; k++) 
                {
                    yield return null;

                    for(int l = 0; l < Chunks[i,j].Y; l++) 
                    {
                        tiles[(i * God.ChunkMagnitude) + k,(j * God.ChunkMagnitude) + l] = Chunks[i,j].GetTileByIndex(k, l);
                        Debug.Log(tiles[(i * God.ChunkMagnitude) + k, (j * God.ChunkMagnitude) + l].Properties.x + " X & " + 
                            tiles[(i * God.ChunkMagnitude) + k, (j * God.ChunkMagnitude) + l].Properties.y + " Y ADDED TO TILES ");
                    }
                }
            }
        }
    }
    private void Awake()
    {
        StartCoroutine(InitializeMe());
    }
}
