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
public enum CreatureType { D = 10, C = 20, B = 30, A = 40, Z = 50, Legendary = 60, Acient = 70}
public enum CreatureElement { Water , Plant, Fire, Air, Ground, Electric, Ice, Light, Dark, Posion}
