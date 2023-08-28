using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MapGeneratorMode { None, Start, Restart, ResetAndLoad, Save }
public class MapGenerator : MonoBehaviour
{
    public static MapGenerator mapGenerator;
    [SerializeField] private SeedProperties seed;
    public SeedProperties Seed { get => seed; set => seed = value;}
    public Action<MapGeneratorMode> InvokeMe;    
    
    private float CalculateNoise(float x, float y) 
    {
        float noise = Mathf.PerlinNoise((x + seed.seed + (seed.seed + seed.dimension5)+ (seed.seed * seed.dimension4 * seed.dimension5))  / seed.scale,
            (y + seed.dimension6 + (seed.seed + seed.dimension5) + (seed.seed * seed.dimension4 * seed.dimension5)) / seed.scale) ;
        
        return noise;
    }
    private IEnumerator StartWorld()
    {
        for(int n = 0; n < Matrix.matrix.MapProperties.ExtentionX; n++)
        {
            yield return null;

            for (int m = 0; m < Matrix.matrix.MapProperties.ExtentionY; m++) 
            {
                Matrix.tiles[n,m].tileInstance = Instantiate(TileSet.tileset.GetBioma(0).GetTilePrefab(CalculateNoise(n,m), 
                    out Matrix.tiles[n,m].Properties.level), 
                    new Vector3(n,m,0f),Quaternion.identity);
            }
        }
    }
    public void RestartWorld(MapGeneratorMode mode) 
    {
        if (mode == MapGeneratorMode.Restart)
        {
            foreach (Tile tile in Matrix.tiles)
            {
                Destroy(tile.tileInstance);
            }
            StartCoroutine(StartWorld());
            Matrix.matrix.SaveMap();
        }
    }
    public void LoadWorld(MapGeneratorMode mode) 
    {

    }
    private void OnEnable()
    {
        InvokeMe += StartWorldCoroutine;
        InvokeMe += SaveWorld;
        InvokeMe += RestartWorld;  
    }
    public void StartWorldCoroutine(MapGeneratorMode mode) { if (mode == MapGeneratorMode.Start)StartCoroutine(StartWorld());}
    public void SaveWorld(MapGeneratorMode mMode) { if (mMode == MapGeneratorMode.Save) Matrix.matrix.SaveMap(); }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R)) InvokeMe(MapGeneratorMode.Restart); 
        if (Input.GetKey(KeyCode.Space)) InvokeMe(MapGeneratorMode.Start); 
        if (Input.GetKey(KeyCode.S)) InvokeMe(MapGeneratorMode.Save);

    }
}
