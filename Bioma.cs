using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Bioma" , fileName = "New Bioma")]
public class Bioma : ScriptableObject
{
    //[SerializeField] private Sprite[] sprites;
    [SerializeField] private Color[] _tileColor;
    [SerializeField] [Range(0.0f, 1f)] private float[] levels;


    public Color GetTileColorByLevel(int level) 
    {
        return _tileColor[level];
    }
    public Color GetTileColorByLevel(int level, out bool walkable, out bool constructable, out bool haveEffect) 
    {
        switch (level) 
        {
            case 0:
                walkable = false;
                constructable = false;
                haveEffect = true;
                return _tileColor[0];
            case 1:
                walkable = false;
                constructable = false;
                haveEffect = true;
                return _tileColor[1];
            case 2:
                walkable = false;
                constructable = false;
                haveEffect = true;
                return _tileColor[2];
            case 3:
                walkable = true;
                constructable = false;
                haveEffect = false;
                return _tileColor[3];
            case 4:
                walkable = true;
                constructable = true;
                haveEffect = false;
                return _tileColor[4];
            case 5:
                walkable = true;
                constructable = true;
                haveEffect = false;
                return _tileColor[5];
            case 6:
                walkable = true;
                constructable = true;
                haveEffect = false;
                return _tileColor[6];
            case 7:
                walkable = true;
                constructable = true;
                haveEffect = false;
                return _tileColor[7];
            case 8:
                walkable = false;
                constructable = false;
                haveEffect = false;
                return _tileColor[8];
            case 9:
                walkable = false;
                constructable = false;
                haveEffect = false;
                return _tileColor[9];
                    default:
                        walkable = false;
                        constructable = false;
                        haveEffect = false;
                        return _tileColor[9];
        }
    }
    public Color GetColorByPerlin(float LevelNumberFloat,out int level,out bool walkable,out bool constructable, out bool haveEffect) {
        if (LevelNumberFloat < levels[0])
        {
            level = 0;
            walkable = false;
            constructable = false;
            haveEffect = true;

            return _tileColor[0];
        }
        else if (LevelNumberFloat < levels[1])
        {
            level = 1;
            walkable = false;
            constructable = false;
            haveEffect = true;
            return _tileColor[1];
        }
        else if (LevelNumberFloat < levels[2])
        {
            level = 2;
            walkable = false;
            constructable = false;
            haveEffect = true;
            return _tileColor[2];
        }
        else if (LevelNumberFloat < levels[3])
        {
            level = 3;
            walkable = true;
            constructable = false;
            haveEffect = false;
            return _tileColor[3];
        }
        else if (LevelNumberFloat < levels[4])
        {
            level = 4;
            walkable = true;
            constructable = true;
            haveEffect = false;
            return _tileColor[4];
        }
        else if (LevelNumberFloat < levels[5])
        {
            level = 5;
            walkable = true;
            constructable = true;
            haveEffect = false;
            return _tileColor[5];
        }
        else if (LevelNumberFloat < levels[6])
        {
            level = 6;
            walkable = true;
            constructable = true;
            haveEffect = false;
            return _tileColor[6];
        }
        else if (LevelNumberFloat < levels[7])
        {
            level = 7;
            walkable = true;
            constructable = true;
            haveEffect = false;
            return _tileColor[7];
        }
        else if (LevelNumberFloat < levels[8])
        {
            level = 8;
            walkable = false;
            constructable = false;
            haveEffect = false;
            return _tileColor[8];
        }
        else if (LevelNumberFloat <= levels[9])
        {
            level = 9;
            walkable = false;
            constructable = false;
            haveEffect = false;
            return _tileColor[9];
        }
        else 
        { 
            level = 8;
            walkable = false;
            constructable = false;
            haveEffect = false;
            return _tileColor[8]; 
        }
    }
}
