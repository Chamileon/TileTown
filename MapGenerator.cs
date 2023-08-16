using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    private void Start()
    {
       
        for(int n = 0; n < Matrix.propertiesOfMap.x; n++)
        {
            for(int m = 0; m < Matrix.propertiesOfMap.y; m++) 
            {
                Chunk Chunkie = Matrix.GetChunkFromID(n, m);
                
                for (int i = 0; i < God.ChunkMagnitude; i++)
                {
                    for (int j = 0; j < God.ChunkMagnitude; j++)
                    {
                        Tile tile = Chunkie.GetTileByIndex(i, j);
                        if (tile != null)
                        {
                            Instantiate(TileSet.tilePrefab, new Vector3((float)tile.Properties.x, (float)tile.Properties.y, 1), Quaternion.identity);
                        }
                    }
                }
            }
           
        }
    }
}
