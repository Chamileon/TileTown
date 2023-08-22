using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 1f)] private float seed;
    [SerializeField] [Range(1f, 1000f)] private float scale;
    
    private float CalculateNoise(float x, float y) 
    {

        float noise = Mathf.PerlinNoise((x + seed)  / scale, (y + seed) / scale);
        Debug.Log("Noise: " + noise);
        
        return noise;
    }
    private IEnumerator StartWorld()
    {
       
        for(int n = 0; n < Matrix.propertiesOfMap.ExtentionX; n++)
        {
            yield return null;

            for (int m = 0; m < Matrix.propertiesOfMap.ExtentionY; m++) 
            {
                Matrix.tiles[n, m].tileInstance = Instantiate(TileSet.tileset.GetBioma(0).GetTilePrefab(CalculateNoise(n,m)), new Vector3(n,m,0f),Quaternion.identity);
            }
           
        }
    }
    private void Start()
    {
        StartCoroutine(StartWorld());
    }
}
