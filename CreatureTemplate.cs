using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Create Creature Template",fileName = "New Creature")]
public class CreatureTemplate : ScriptableObject
{
    [Header("Basic Info")]
    public new string name;
    [TextArea(3,20)]
    public string description;
    public CreatureType type;
    public bool canBeRecluted, canBeEvolutioned;
    public int levelToEvolution;
    public CreatureElement[] elements;
    [Header("Creature Status")]
    public int basicHealth;
    public int basicMana;
    public int basicAttack;
    public int basicDefense;
    public int basicMagicAttack;
    public int basicMagicDefense;
    public int basicRange;
}
public enum CreatureType { D, C, B, A, Z, Legendary, Acient}
public enum CreatureElement { Water , Plant, Fire, Air, Ground, Electric, Ice, Light, Dark, Posion}
