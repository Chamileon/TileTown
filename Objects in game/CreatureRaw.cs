using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CreatureRaw
{
    [SerializeField] private CreatureTemplate creatureTemplate;
    [SerializeField] private int actualLvl;
    [SerializeField] private int actualHealth;
    [SerializeField] private int actualMana;
    [SerializeField] private int actualAtk;
    [SerializeField] private int actualDef;
    [SerializeField] private int actualMAtk;
    [SerializeField] private int actualMDef;
    [SerializeField] private int actualRange;
    [SerializeField] private CreatureStatus _status = CreatureStatus.None;
    public CreatureTemplate CreatureTemplate { get { return creatureTemplate; } set { creatureTemplate = value; } }
    public CreatureRaw(CreatureTemplate creature, int lvl)
    {
        creatureTemplate = creature;
        SetLvl(lvl);
        
    }
    public CreatureStatus Status { get { return _status; } private set { _status = value; } }
    public void SetStatus(CreatureStatus newStatus) 
    {
        if(newStatus == CreatureStatus.None ) { Status = newStatus; }
    }
    public void ResetStatus() { Status = CreatureStatus.None; }
    public void SetLvl(int lvl) 
    {
        actualLvl = lvl;
        CalculateStatuses(lvl);

    }
    private void CalculateStatuses(int lvl) 
    {
        actualHealth = creatureTemplate.basicHealth + CalculateHP(creatureTemplate.elements[0], lvl);
        actualMana = creatureTemplate.basicMana + CalculateMana(creatureTemplate.elements[0], lvl);
        actualAtk = creatureTemplate.basicAttack + CalculateATK(creatureTemplate.elements[0], lvl);
        actualDef = creatureTemplate.basicDefense + CalculateDEF(creatureTemplate.elements[0], lvl);
        actualMAtk = creatureTemplate.basicMagicAttack + CalculateMATK(creatureTemplate.elements[0], lvl);
        actualMDef = creatureTemplate.basicMagicDefense + CalculateMDEF(creatureTemplate.elements[0], lvl);
        
    }
    private int CalculateHP(CreatureElement element, int lvl) 
    {
        switch (element) 
        {
            case CreatureElement.Water:
                return lvl * 2;
            case CreatureElement.Fire:
                return lvl * 0;
            case CreatureElement.Plant:
                return lvl * 2;
            case CreatureElement.Electric:
                return lvl * 0;
            case CreatureElement.Air:
                return lvl * 1;
            case CreatureElement.Ice:
                return lvl * 1;
            case CreatureElement.Ground:
                return lvl * 3;
            case CreatureElement.Light:
                return lvl * 3;
            case CreatureElement.Dark:
                return lvl * 0;
            case CreatureElement.Poison:
                return lvl * 0;
                default: return 0;
        }
    }
    private int CalculateMana(CreatureElement element, int lvl) 
    {
        switch (element)
        {
            case CreatureElement.Water:
                return lvl * 1;
            case CreatureElement.Fire:
                return lvl * 3;
            case CreatureElement.Plant:
                return lvl * 2;
            case CreatureElement.Electric:
                return lvl * 1;
            case CreatureElement.Air:
                return lvl * 1;
            case CreatureElement.Ice:
                return lvl * 2;
            case CreatureElement.Ground:
                return lvl * 1;
            case CreatureElement.Light:
                return lvl * 2;
            case CreatureElement.Dark:
                return lvl * 1;
            case CreatureElement.Poison:
                return lvl * 0;
            default: return 0;
        }
    }
    private int CalculateATK(CreatureElement element, int lvl) 
    {
        switch (element)
        {
            case CreatureElement.Water:
                return lvl * 2;
            case CreatureElement.Fire:
                return lvl * 0;
            case CreatureElement.Plant:
                return lvl * 2;
            case CreatureElement.Electric:
                return lvl * 2;
            case CreatureElement.Air:
                return lvl * 2;
            case CreatureElement.Ice:
                return lvl * 1;
            case CreatureElement.Ground:
                return lvl * 2;
            case CreatureElement.Light:
                return lvl * 0;
            case CreatureElement.Dark:
                return lvl * 3;
            case CreatureElement.Poison:
                return lvl * 1;
            default: return 0;
        }
    }
    private int CalculateDEF(CreatureElement element, int lvl) 
    {
        switch (element)
        {
            case CreatureElement.Water:
                return lvl * 2;
            case CreatureElement.Fire:
                return lvl * 1;
            case CreatureElement.Plant:
                return lvl * 1;
            case CreatureElement.Electric:
                return lvl * 0;
            case CreatureElement.Air:
                return lvl * 1;
            case CreatureElement.Ice:
                return lvl * 0;
            case CreatureElement.Ground:
                return lvl * 2;
            case CreatureElement.Light:
                return lvl * 0;
            case CreatureElement.Dark:
                return lvl * 1;
            case CreatureElement.Poison:
                return lvl * 0;
            default: return 0;
        }
    }
    private int CalculateMATK(CreatureElement element, int lvl) 
    {
        switch (element)
        {
            case CreatureElement.Water:
                return lvl * 1;
            case CreatureElement.Fire:
                return lvl * 2;
            case CreatureElement.Plant:
                return lvl * 2;
            case CreatureElement.Electric:
                return lvl * 3;
            case CreatureElement.Air:
                return lvl * 3;
            case CreatureElement.Ice:
                return lvl * 2;
            case CreatureElement.Ground:
                return lvl * 0;
            case CreatureElement.Light:
                return lvl * 1;
            case CreatureElement.Dark:
                return lvl * 2;
            case CreatureElement.Poison:
                return lvl * 3;
            default: return 0;
        }
    }
    private int CalculateMDEF(CreatureElement element, int lvl) 
    {
        switch (element)
        {
            case CreatureElement.Water:
                return lvl * 0;
            case CreatureElement.Fire:
                return lvl * 1;
            case CreatureElement.Plant:
                return lvl * 0;
            case CreatureElement.Electric:
                return lvl * 1;
            case CreatureElement.Air:
                return lvl * 0;
            case CreatureElement.Ice:
                return lvl * 3;
            case CreatureElement.Ground:
                return lvl * 0;
            case CreatureElement.Light:
                return lvl * 2;
            case CreatureElement.Dark:
                return lvl * 1;
            case CreatureElement.Poison:
                return lvl * 2;
            default: return 0;
        }
    }
    
    
}
public enum CreatureStatus { None ,Shocked, stunned, Slept, WaitingOneTurn, WaitingTwoTurns, Poisoned, Slowed, Blinded,AtkBuffed, DefBuffed, SpeedBuffed, RangeBuffed, HealthBuffed, ManaBuffed };
