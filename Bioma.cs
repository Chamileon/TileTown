using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Bioma" , fileName = "New Bioma")]
public class Bioma : ScriptableObject
{
    [SerializeField] private Sprite[] sprites;
    public Sprite GetSprite(int BiomaNumber) { return sprites[BiomaNumber]; }
}
