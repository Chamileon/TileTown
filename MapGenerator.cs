using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MapGeneratorMode { None, Start, Restart, ResetAndLoad, SaveSeed, SaveMap }
public class MapGenerator : MonoBehaviour
{
    public MapGeneratorMode mode;
    public static MapGenerator mapGenerator;
    public int mapSavesNumber = 15;
    public MapSave[] mapSaves;
    [SerializeField] private SeedProperties seed;
    public SeedProperties Seed { get => seed; set => seed = value;}
    public Action<MapGeneratorMode> InvokeMe;    
    
    private float CalculateNoise(float x, float y) 
    {
        float noise = Mathf.PerlinNoise((x + seed.seed + (seed.seed + seed.dimension5)+ (seed.seed * seed.dimension4 * seed.dimension5))  / seed.scale,
            (y + seed.dimension6 + (seed.seed + seed.dimension5) + (seed.seed * seed.dimension4 * seed.dimension5)) / seed.scale) ;
        
        return noise;
    }
    private IEnumerator StartWorld(int bioma)
    {
        for(int n = 0; n < Matrix.matrix.MapProperties.ExtentionX; n++)
        {
            yield return null;
            for (int m = 0; m < Matrix.matrix.MapProperties.ExtentionY; m++) 
            {
                Matrix.tiles[n,m].tileInstance = Instantiate(TileSet.tileset.GetBioma(bioma).GetTilePrefab(CalculateNoise(n,m), 
                    out Matrix.tiles[n,m].Properties.level), 
                    new Vector3(n,m,0f),Quaternion.identity);
            }
        }
    }
    public void RestartWorld(MapGeneratorMode mode) 
    {
        if (mode == MapGeneratorMode.Restart)
        {
            DeleteWorld();
            StartCoroutine(StartWorld(0));
        }
    }
    private void DeleteWorld() 
    {
        foreach (Tile tile in Matrix.tiles)
        {
            Destroy(tile.tileInstance);
        }
    }
    public void LoadWorld(MapGeneratorMode mode) 
    {
        if(mode == MapGeneratorMode.ResetAndLoad) 
        {
            DeleteWorld();

        }
    }
    private void OnEnable()
    {
        InvokeMe += StartWorldCoroutine;
        InvokeMe += SaveSeed;
        InvokeMe += RestartWorld;
        InvokeMe += SaveMap;
        InvokeMe += LoadMap;
    }
    public void StartWorldCoroutine(MapGeneratorMode mode) { if (mode == MapGeneratorMode.Start) StartCoroutine(StartWorld(0));}
    public void SaveSeed(MapGeneratorMode mode) { if (mode == MapGeneratorMode.SaveSeed) Matrix.matrix.SaveSeed(); }
    public void SaveMap(MapGeneratorMode mode) 
    {
        if (mode == MapGeneratorMode.SaveMap)
        {
            int x, y;
            x = Matrix.matrix.MapProperties.ExtentionX;
            y = Matrix.matrix.MapProperties.ExtentionY;
            mapSaves[0].Levels = new int[x,y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0;j < y; j++)
                {
                    mapSaves[0].Levels[i,j] = Matrix.tiles[i, j].Properties.level;
                }
            }
        }
    }
    public void LoadMap(MapGeneratorMode mode) 
    {
        if (mode == MapGeneratorMode.ResetAndLoad) { StartCoroutine(MapSaveLoader(mapSaves[mapSavesNumber])); }
    }
    IEnumerator MapSaveLoader(MapSave ms) 
    {
        DeleteWorld();
        int x, y;
        x = Matrix.matrix.MapProperties.ExtentionX;
        y = Matrix.matrix.MapProperties.ExtentionY;
        for (int i = 0; i < x; i++)
        {
            yield return null;
            for (int j = 0; j < y; j++)
            {
                
                Matrix.tiles[i, j].tileInstance = Instantiate(
                    TileSet.tileset.GetBioma(ms.Bioma).GetTilePrefab(ms.Levels[i, j],
                    out Matrix.tiles[i, j].Properties.level),
                    new Vector3(i, j, 0f), Quaternion.identity);
            }
        }
    }
    private void Update()
    { 
        if (Input.GetKey(KeyCode.Space)) InvokeMe(mode);
    }
}
