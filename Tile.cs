using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tile : MonoBehaviour
{
    [SerializeField] private TileProperties properties;
    [SerializeField] private Sprite sprite;

    public TileProperties Properties { get => properties; set => properties = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }  
}


public  class TileProperties : MonoBehaviour
{
    [SerializeField] public int x, y;
    [SerializeField] public int walkable, constructable,haveEffect;
}