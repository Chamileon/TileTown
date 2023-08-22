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
    [Space]
    public int levelToEvolution;
    [Header("Creature Status")]
    public int basicHealth;
    public int basicMana;
    public int basicAttack;
    public int basicDefense;
    public int basicAttackSpeed;
    public int basicMagicAttack;
    public int basicMagicDefense;
}
public enum CreatureType { D, C, B, A, Z, Legendary, Acient}
