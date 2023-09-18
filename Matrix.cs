using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu(menuName: "Matrix")]
[RequireComponent(typeof(MapGenerator))]
[RequireComponent(typeof(God))]
public class Matrix : MonoBehaviour {

    public static Matrix matrix;
    public static Chunk[,] Chunks;
    public static Tile[,] Tiles;
    [SerializeField] private MapProperties _mapProperties;
    public MapProperties MapProperties { get => _mapProperties; set { _mapProperties = value; } }
    public  void SaveMap() 
    {
        _mapProperties.Seed = MapGenerator.mapGenerator.Seed;
    }
    public void DeleteTiles()
    {
        foreach (var tile in Tiles) 
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
        _mapProperties.Seed = properties;
    }
    public Chunk GetChunkFromID(int X, int Y) { return Chunks[X, Y]; }
    public Tile GetTileFromID(int indexXChunk, int indexYChunk,int indexTileX, int indexTileY)
    {
        return GetChunkFromID(indexXChunk, indexYChunk).GetTileByIndex(indexTileX, indexTileY);
    }
    public Tile GetTileFromID(int indexXTile,int indexYTile) { return Tiles[indexXTile, indexYTile]; }
    IEnumerator InitializeMe() 
    {
        matrix = this;
        Chunks = new Chunk[_mapProperties.X, _mapProperties.Y];
        Tiles = new Tile[_mapProperties.ExtentionX,_mapProperties.ExtentionY];
        for (int i = 0; i < _mapProperties.X; i++)
        {

            for (int j = 0; j < _mapProperties.Y; j++)
            {
                Chunks[i, j] = new Chunk(i, j);
                for (int k = 0; k < Chunks[i,j].X; k++) 
                {
                    yield return null;

                    for(int l = 0; l < Chunks[i,j].Y; l++) 
                    {
                        Tiles[(i * God.ChunkMagnitude) + k,(j * God.ChunkMagnitude) + l] = Chunks[i,j].GetTileByIndex(k, l);
                        Tile t = Tiles[(i * God.ChunkMagnitude) + k, (j * God.ChunkMagnitude) + l];
                        t.tileInstance = Instantiate(TileSet.tileset.TilePrefab, SetTilesInMap(t.Properties.x, t.Properties.y), Quaternion.identity);
                        Debug.Log(Tiles[(i * God.ChunkMagnitude) + k, (j * God.ChunkMagnitude) + l].Properties.x + " X & " + 
                            Tiles[(i * God.ChunkMagnitude) + k, (j * God.ChunkMagnitude) + l].Properties.y + " Y ADDED TO TILES ");
                    }
                }
            }
        }
        MapGenerator.mapGenerator.InitializeGame();
        God.god.IsNextStepReady = true;
        WindowsController.controller.OpenCloseWindows(false);

    }
    private Vector3 SetTilesInMap(int x, int y) 
    {
        Vector3 insertion = new Vector3(x + 0.5f, y + 0.5f, 0f);
        return insertion;
    }
    private void Awake()
    {
        StartCoroutine(InitializeMe());
    }
}
