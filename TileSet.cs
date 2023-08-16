using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSet : MonoBehaviour
{
    public static TileSet tileset;
    public static GameObject tilePrefab;
    [SerializeField] private GameObject tilesPrefab;
    [SerializeField] private Bioma[] biomas;


    public Bioma GetBioma(int i) { return biomas[i];}
    public Sprite GetSpriteFromBioma(int BiomaNumber, int SpriteNumber) 
    { 
        return GetBioma(BiomaNumber).GetSprite(SpriteNumber);
    }
    private void Awake()
    {
        Singleton();
        InitializeMe();
    }
    private void Singleton() 
    {
        if (tileset == null) { tileset = this; } else { Destroy(gameObject); }
    }
    private void InitializeMe() 
    {
        tilePrefab = tilesPrefab;
    }
}