using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator mapGenerator;
    [SerializeField] public static SeedProperties seed;
    [SerializeField] private SeedProperties Pseed;
    [SerializeField] private bool reset;
    public delegate void theDelegate();
    public theDelegate InvokeMe;
    
    
    private float CalculateNoise(float x, float y) 
    {

        float noise = Mathf.PerlinNoise((x + seed.seed + (seed.seed + seed.dimension5)+ (seed.seed * seed.dimension4 * seed.dimension5))  / seed.scale,
            (y + seed.dimension6 + (seed.seed + seed.dimension5) + (seed.seed * seed.dimension4 * seed.dimension5)) / seed.scale) ;
        
        return noise;
    }
    private IEnumerator StartWorld()
    {
        seed = Pseed;
        for(int n = 0; n < Matrix.map.ExtentionX; n++)
        {
            yield return null;

            for (int m = 0; m < Matrix.map.ExtentionY; m++) 
            {
                Matrix.tiles[n, m].tileInstance = Instantiate(TileSet.tileset.GetBioma(0).GetTilePrefab(CalculateNoise(n,m)), new Vector3(n,m,0f),Quaternion.identity);
            }
           
        }
    }
    public void ResetWorld() 
    {
        foreach( Tile tile in Matrix.tiles) 
        {
            
            Destroy(tile.tileInstance); 
            

        }
        StartCoroutine(StartWorld());
        Matrix.SaveMap();
        reset = false;
    }
    private void Start()
    {
        StartCoroutine(StartWorld());
        InvokeMe = new theDelegate(ResetWorld);   
    }
    public void StartWorldCoroutine() { StartCoroutine(StartWorld()); Matrix.SaveMap(); }

    private void Update()
    {
        if (Input.anyKeyDown && reset) { InvokeMe(); reset = false; }
    }
}
