using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CreatureRaw
{
    [SerializeField] private CreatureTemplate _creatureTemplate;
    [SerializeField] private int _actualLvl;
    [SerializeField] private int _actualHealth;
    [SerializeField] private int _actualMana;
    [SerializeField] private int _actualAtk;
    [SerializeField] private int _actualDef;
    [SerializeField] private int _actualMAtk;
    [SerializeField] private int _actualMDef;
    [SerializeField] private int _actualRange;
    [SerializeField] private CreatureStatus _status = CreatureStatus.None;

    public CreatureRaw(CreatureTemplate creature, int lvl)
    {
        _creatureTemplate = creature;
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
        _actualLvl = lvl;
        CalculateStatuses(lvl);

    }
    private void CalculateStatuses(int lvl) 
    {
        _actualHealth = _creatureTemplate.basicHealth + CalculateHP(_creatureTemplate.elements[0], lvl);
        _actualMana = _creatureTemplate.basicMana + CalculateMana(_creatureTemplate.elements[0], lvl);
        _actualAtk = _creatureTemplate.basicAttack + CalculateATK(_creatureTemplate.elements[0], lvl);
        _actualDef = _creatureTemplate.basicDefense + CalculateDEF(_creatureTemplate.elements[0], lvl);
        _actualMAtk = _creatureTemplate.basicMagicAttack + CalculateMATK(_creatureTemplate.elements[0], lvl);
        _actualMDef = _creatureTemplate.basicMagicDefense + CalculateMDEF(_creatureTemplate.elements[0], lvl);
        
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
            case CreatureElement.Posion:
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
            case CreatureElement.Posion:
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
            case CreatureElement.Posion:
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
            case CreatureElement.Posion:
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
            case CreatureElement.Posion:
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
            case CreatureElement.Posion:
                return lvl * 2;
            default: return 0;
        }
    }
    private void ActualiceData(int lvl, int hp, int mana, int atk, int def, int spd, int matk, int mdef) 
    {
        _actualLvl = lvl;
        _actualHealth = hp;
        _actualMana = mana;
        _actualAtk = atk;
        _actualDef = def;
        _actualMAtk = matk;
        _actualMDef = mdef;
    }
    
}
public enum CreatureStatus { None ,Shocked, stunned, Slept, WaitingOneTurn, WaitingTwoTurns, Poisoned, Slowed, Blinded,AtkBuffed, DefBuffed, SpeedBuffed, RangeBuffed, HealthBuffed, ManaBuffed };
