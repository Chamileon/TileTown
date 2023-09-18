using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSet : MonoBehaviour
{
    public static TileSet tileset;
    [SerializeField] private GameObject tilePrefab;
    public GameObject TilePrefab { get { return tilePrefab; } }
    [SerializeField] private Bioma[] biomas;


    public Bioma GetBioma(int i) { return biomas[i];}
    /*public Sprite GetSpriteFromBioma(int BiomaNumber, int SpriteNumber) 
    { 
        return GetBioma(BiomaNumber).GetSprite(SpriteNumber);
    }*/
    private void Awake()
    {

        InitializeMe();
    }
    
    private void InitializeMe() 
    {
        tileset = this;
    }
}
