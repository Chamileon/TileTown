using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Bioma" , fileName = "New Bioma")]
public class Bioma : ScriptableObject
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject[] tilesPrefab;
    public Sprite GetSprite(int BiomaNumber) { return sprites[BiomaNumber]; }
    public GameObject GetTilePrefab(float LevelNumber) {
        if(LevelNumber < 0.1f)
        {
            return tilesPrefab[0];
        }
        else if (LevelNumber < 0.2f)
        {
            return tilesPrefab[1];
        }
        else if (LevelNumber < 0.3f)
        {
            return tilesPrefab[2];
        }
        else if (LevelNumber < 0.4f)
        {
            return tilesPrefab[3];
        } 
        else if (LevelNumber < 0.5f) 
        {
            return tilesPrefab[4];
        }
        else if (LevelNumber < 0.6f)
        {
            return tilesPrefab[5];
        }
        else if (LevelNumber < 0.7f)
        {
            return tilesPrefab[6];
        }
        else if(LevelNumber < 0.8f)
        {
            return tilesPrefab[7];
        }
        else if(LevelNumber < 0.9f)
        {
            return tilesPrefab[8];
        }
        else if (LevelNumber <= 1f) 
        {
            return tilesPrefab[9];
        }
        else return null;
    }
}
