using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public enum MapGeneratorMode { None, Start, Restart, SaveSeed, LoadSeed, SaveMap, ResetAndLoad, SaveEverything }
[RequireComponent(typeof(Matrix))]
[RequireComponent(typeof(God))]

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator mapGenerator;
    public MapGeneratorMode Mode;
    [Header("Save System")]
    [SerializeField] [Range(0, 14)] private int selectMapPath;
    [SerializeField] private string[] mapSavesPath;
    [SerializeField] [Range(0, 0)] private int selectBioma = 0; //Cambiar rango al añadir biomas
    [SerializeField] private SeedProperties seed;
    public SeedProperties Seed { get { return seed; } set { seed = value; } }
    public Action<MapGeneratorMode> InvokeMe;
    private void Awake()
    {
        mapGenerator = this;
    }
    private float CalculateNoise(float x, float y)
    {
        float noise = Mathf.PerlinNoise((x + seed.seed + (seed.seed + seed.dimension5) + (seed.seed * seed.dimension4 * seed.dimension5)) / seed.scale,
            (y + seed.dimension6 + (seed.seed + seed.dimension5) + (seed.seed * seed.dimension4 * seed.dimension5)) / seed.scale);

        return noise;
    }
    private IEnumerator StartWorld(int bioma)
    {

        for (int n = 0; n < Matrix.matrix.MapProperties.ExtentionX; n++)
        {
            yield return null;

            for (int m = 0; m < Matrix.matrix.MapProperties.ExtentionY; m++)
            {
                Matrix.Tiles[n, m].tileInstance.GetComponent<SpriteRenderer>().color = TileSet.tileset.GetBioma(bioma).GetColorByPerlin(CalculateNoise(n, m),
                    out Matrix.Tiles[n, m].Properties.level,
                    out Matrix.Tiles[n, m].Properties.walkable,
                    out Matrix.Tiles[n, m].Properties.constructable,
                    out Matrix.Tiles[n, m].Properties.haveEffect);
            }
        }
    }
    private void RestartWorld(MapGeneratorMode mode)
    {
        if (mode == MapGeneratorMode.Restart)
        {
            DeleteWorld();
            StartWorldCoroutine(MapGeneratorMode.Start);
        }
    }
    private void DeleteWorld()
    {
        foreach (Tile tile in Matrix.Tiles)
        {
            tile.tileInstance.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
    private void SaveEverything(MapGeneratorMode mode)
    {
        if (mode == MapGeneratorMode.SaveEverything)
        {
            SaveSeed(MapGeneratorMode.SaveSeed);
            SaveMap(MapGeneratorMode.SaveMap);
        }
    }

    private void OnEnable()
    {
        /// añadir coroutines del invokeme : InvokeMe += Metodo;
        InvokeMe += StartWorldCoroutine;
        InvokeMe += RestartWorld;
        InvokeMe += SaveSeed;
        InvokeMe += LoadSeed;
        InvokeMe += SaveMap;
        InvokeMe += LoadMap;
        InvokeMe += SaveEverything;
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
    public void StartWorldCoroutine(MapGeneratorMode mode) { if (mode == MapGeneratorMode.Start) StartCoroutine(StartWorld(selectBioma)); }
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
                Debug.Log("Paso 01");
                for (int j = 0; j < y; j++)
                {
                    TileProperties prop = Matrix.Tiles[i, j].Properties;
                    mapFile.Add(i, j, prop.level, prop.walkable, prop.constructable, prop.haveEffect);
                }
            }
            string dataPath = Application.persistentDataPath + mapSavesPath[selectMapPath];
            Debug.Log(dataPath + " is datapath.");
            FileStream fileStream = new FileStream(dataPath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStream, mapFile);
            fileStream.Close();

        }
    }
    public void LoadMap(MapGeneratorMode mode)
    {
        if (mode == MapGeneratorMode.ResetAndLoad) 
        {
            Debug.Log("Map Loading");
            StartCoroutine(MapLoader());
        }
    }
    IEnumerator MapLoader()
    {
        DeleteWorld();
        int x, y;
        x = Matrix.matrix.MapProperties.ExtentionX;
        y = Matrix.matrix.MapProperties.ExtentionY;
        MapFile mapFile = new MapFile();
        string dataPath = Application.persistentDataPath + mapSavesPath[selectMapPath];
        Debug.Log(dataPath + " is datapath loaded");
        if (File.Exists(dataPath))
        {
            FileStream fs = File.OpenRead(dataPath);
            BinaryFormatter bf = new BinaryFormatter();
            mapFile = (MapFile)bf.Deserialize(fs);
            for (int i = 0; i < x; i++)
            {
                yield return null;
                for (int j = 0; j < y; j++)
                {
                    Tile t = Matrix.Tiles[i, j];
                    t.tileInstance.GetComponent<SpriteRenderer>().color = TileSet.tileset.GetBioma(mapFile.Bioma).GetTileColorByLevel(mapFile.levelOfTile[i, j]);
                    TileProperties prop = t.Properties;
                    prop.level = mapFile.levelOfTile[i, j];
                    prop.walkable = mapFile.walkable[i, j];
                    prop.constructable = mapFile.constructable[i, j];
                    prop.haveEffect = mapFile.haveEffect[i, j];
                }
            }
        }
    }
    public void InitializeGame()
    {
        InvokeMe(MapGeneratorMode.Start);
        Mode = MapGeneratorMode.None;

    }
}
