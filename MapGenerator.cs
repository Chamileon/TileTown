using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public enum MapGeneratorMode { None, Start, Restart, SaveSeed, LoadSeed, SaveMap, SaveEverything, ResetAndLoad }
[RequireComponent(typeof(Matrix))]
[RequireComponent(typeof(God))]

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator mapGenerator;
    public MapGeneratorMode mode;
    [Header("Save System")]
    [SerializeField] [Range(0, 14)] private int selectMapPath;
    [SerializeField] private string[] mapSavesPath;
    [SerializeField] [Range(0,0)] private int selectBioma = 0; //Cambiar rango al añadir biomas
    [SerializeField] private SeedProperties seed;
    public SeedProperties Seed { get { return seed; } set { seed = value; } }
    public Action<MapGeneratorMode> InvokeMe;
    private void Awake()
    {
        mapGenerator = this;
    }
    private float CalculateNoise(float x, float y) 
    {
        float noise = Mathf.PerlinNoise((x + seed.seed + (seed.seed + seed.dimension5)+ (seed.seed * seed.dimension4 * seed.dimension5))  / seed.scale,
            (y + seed.dimension6 + (seed.seed + seed.dimension5) + (seed.seed * seed.dimension4 * seed.dimension5)) / seed.scale) ;
        
        return noise;
    }
    private IEnumerator StartWorld(int bioma)
    {
        DeleteWorld();
        for(int n = 0; n < Matrix.matrix.MapProperties.ExtentionX; n++)
        {
            yield return null;
            
            for (int m = 0; m < Matrix.matrix.MapProperties.ExtentionY; m++) 
            {
                Matrix.tiles[n, m].tileInstance = Instantiate(TileSet.tileset.GetBioma(bioma).GetTileByPerlin(CalculateNoise(n, m), 
                    out Matrix.tiles[n, m].Properties.level), 
                    new Vector3(n, m, 0f),Quaternion.identity);
            }
        }
    }
    private void RestartWorld(MapGeneratorMode mode) 
    {
        if (mode == MapGeneratorMode.Restart)
        {
            DeleteWorld();
            StartCoroutine(StartWorld(selectBioma));
        }
    }
    private void DeleteWorld() 
    {
        Debug.Log("Delete¡¡¡");
        Matrix.matrix.DeleteTiles();
    }
    private void SaveEverything(MapGeneratorMode mode) 
    {
        if(mode == MapGeneratorMode.SaveEverything) 
        {
            SaveSeed(MapGeneratorMode.SaveSeed);
            SaveMap(MapGeneratorMode.SaveMap);

        }
    }
    
    private void OnEnable()
    {
        InvokeMe += StartWorldCoroutine;
        InvokeMe += SaveSeed;
        InvokeMe += LoadSeed;
        InvokeMe += RestartWorld;
        InvokeMe += SaveMap;
        InvokeMe += LoadMap;
        InvokeMe += SaveEverything;
     }
    public void StartWorldCoroutine(MapGeneratorMode mode) { if (mode == MapGeneratorMode.Start) StartCoroutine(StartWorld(selectBioma));}
    public void SaveSeed(MapGeneratorMode mode) { if (mode == MapGeneratorMode.SaveSeed) Matrix.matrix.SaveSeed(); }
    public void SaveMap(MapGeneratorMode mode) 
    {
        if (mode == MapGeneratorMode.SaveMap)
        {
            int x, y;
            x = Matrix.matrix.MapProperties.ExtentionX;
            y = Matrix.matrix.MapProperties.ExtentionY;
            MapFile mapFile = new MapFile();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0;j < y; j++)
                {
                    mapFile.AddLevel(Matrix.tiles[i,j].Properties.level, i, j);
                }
            }
            string dataPath = Application.persistentDataPath + mapSavesPath[selectMapPath];
            FileStream fileStream = new FileStream(dataPath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStream, mapFile);
            fileStream.Close();

        }
    }
    public void LoadSeed(MapGeneratorMode mode) 
    {
        if(mode == MapGeneratorMode.LoadSeed) 
        {
            DeleteWorld();
            Matrix.matrix.LoadSeed();
            StartWorldCoroutine(MapGeneratorMode.Start);
        }
    }
    public void LoadMap(MapGeneratorMode mode) 
    {
        if (mode == MapGeneratorMode.ResetAndLoad) { StartCoroutine(MapLoader()); }
                                                   
    }
    IEnumerator MapLoader() 
    {
        DeleteWorld();
        int x, y;
        x = Matrix.matrix.MapProperties.ExtentionX;
        y = Matrix.matrix.MapProperties.ExtentionY;
        MapFile mapFile = new MapFile();
        string dataPath = Application.persistentDataPath + mapSavesPath[selectMapPath];
        if (File.Exists(dataPath)) 
        {
            FileStream fs = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            mapFile = (MapFile)bf.Deserialize(fs);
            for (int i = 0; i < x; i++)
            {
                yield return null;
                for (int j = 0; j < y; j++)
                {
                    Matrix.tiles[i, j].tileInstance = Instantiate(TileSet.tileset.GetBioma(mapFile.Bioma).GetTileByInt(mapFile.levelOfTile[i, j]),
                        new Vector3(i, j, 0f), Quaternion.identity);
                
                               
                }
            }
        }
        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) { InvokeMe(mode); mode = MapGeneratorMode.None; }
    }
}
