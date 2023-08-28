using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Bioma" , fileName = "New Bioma")]
public class Bioma : ScriptableObject
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject[] tilesPrefab;
    [SerializeField] [Range(0.0f, 1f)] private float[] levels;
    public Sprite GetSprite(int BiomaNumber) { return sprites[BiomaNumber]; }
    public GameObject GetTilePrefab(float LevelNumber, out int level) {
        if (LevelNumber < levels[0])
        {
            level = 0;
            return tilesPrefab[0];
        }
        else if (LevelNumber < levels[1])
        {
            level = 1;
            return tilesPrefab[1];
        }
        else if (LevelNumber < levels[2])
        {
            level = 2;
            return tilesPrefab[2];
        }
        else if (LevelNumber < levels[3])
        {
            level = 3;
            return tilesPrefab[3];
        }
        else if (LevelNumber < levels[4])
        {
            level = 4;
            return tilesPrefab[4];
        }
        else if (LevelNumber < levels[5])
        {
            level = 5;
            return tilesPrefab[5];
        }
        else if (LevelNumber < levels[6])
        {
            level = 6;
            return tilesPrefab[6];
        }
        else if (LevelNumber < levels[7])
        {
            level = 7;
            return tilesPrefab[7];
        }
        else if (LevelNumber < levels[8])
        {
            level = 8;
            return tilesPrefab[8];
        }
        else if (LevelNumber <= levels[9])
        {
            level = 9;
            return tilesPrefab[9];
        }
        else { level = 8; return tilesPrefab[8]; }
    }
}
