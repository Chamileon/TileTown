using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    [SerializeField] [Range(1, 100f)] private float seed;
    [SerializeField] [Range(1f, 1000f)] private float scale;
    [SerializeField] [Range(1f,10f)] private float fourthDimension;
    [SerializeField] [Range(0.1f,1f)] private float fifthDimension;
    [SerializeField] [Range(1f,2f)] private float SixthDimension;
    [SerializeField] private bool reset;
    public delegate void theDelegate();
    public theDelegate InvokeMe;
    

    
    private float CalculateNoise(float x, float y) 
    {

        float noise = Mathf.PerlinNoise((x + SixthDimension + (seed + fifthDimension)+ (seed * fourthDimension * fifthDimension))  / scale,
            (y + SixthDimension + (seed + fifthDimension) + (seed * fourthDimension * fifthDimension)) / scale) ;
        
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
    public void ResetWorld() 
    {
        foreach( Tile tile in Matrix.tiles) 
        {
            
            Destroy(tile.tileInstance); 
            

        }
        StartCoroutine(StartWorld());
        reset = false;
    }
    private void Start()
    {
        StartCoroutine(StartWorld());
        InvokeMe = new theDelegate(ResetWorld);   
    }
    public void StartWorldCoroutine() { StartCoroutine(StartWorld()); }

    private void Update()
    {
        if (Input.anyKeyDown && reset) { InvokeMe(); reset = false; }
    }
}
