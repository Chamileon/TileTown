using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    public static Zoo zoo;

    [SerializeField] private CreatureTemplate[] _creatures;
    public CreatureTemplate Creature(int index) { return _creatures[index]; }
    public CreatureTemplate CreatureRandom() 
    {
        return _creatures[Random.Range(0, _creatures.Length)];
    }
    public CreatureTemplate CreatureRandom(CreatureType type, CreatureElement element) 
    {
        int index = (int) type;
        List<CreatureTemplate> filtered = new List<CreatureTemplate>(); 
        switch (index)   
        {
            case 10:
                foreach (CreatureTemplate creature in _creatures) 
                {
                    if (FilterCreature(creature, index, element))
                    {
                        filtered.Add(creature);
                    }
                }
            break;
            case 20:
                foreach (CreatureTemplate creature in _creatures)
                {
                    if (FilterCreature(creature, index, element))
                    {
                        filtered.Add(creature);
                    }
                }
                break;
            case 30:
                foreach (CreatureTemplate creature in _creatures)
                {
                    if (FilterCreature(creature, index, element))
                    {
                        filtered.Add(creature);
                    }
                }
                break;
            case 40:
                foreach (CreatureTemplate creature in _creatures)
                {
                    if (FilterCreature(creature, index, element))
                    {
                        filtered.Add(creature);
                    }
                }
                break;
            case 50:
                foreach (CreatureTemplate creature in _creatures)
                {
                    if (FilterCreature(creature, index, element))
                    {
                        filtered.Add(creature);
                    }
                }
                break;
            case 60:
                foreach (CreatureTemplate creature in _creatures)
                {
                    if (FilterCreature(creature, index, element))
                    {
                        filtered.Add(creature);
                    }
                }
                break;
            case 70:
                foreach (CreatureTemplate creature in _creatures)
                {
                    if (FilterCreature(creature, index, element))
                    {
                        filtered.Add(creature);
                    }
                }
                break;
        }
        CreatureTemplate[] templates = filtered.ToArray();
        int i = Random.Range(0, templates.Length);
        return templates[i];
    }
    private bool FilterCreature(CreatureTemplate creature, int lvl, CreatureElement element) 
    {
        bool passfilter = (int)creature.type == lvl ? true : false;
        bool passfilterII = creature.elements[0] == element ? true : false;
        bool pass;
        if(!passfilter || !passfilterII) { return false; }
        else { return true; }
    }
    private void InitializeMe()
    {
        zoo = this;
    }
    private void Awake()
    {
        InitializeMe();
    }
}
