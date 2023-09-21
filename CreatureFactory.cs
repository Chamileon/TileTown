using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum levelRange { IStar = 10, IIStars = 20, IIIStars = 30, IVStars = 40, VStars = 50, VIStars = 60, Master = 80, Legend = 100  }
public static class CreatureFactory
{
    public static CreatureRaw NewCreature(levelRange range) 
    {
        switch (range) 
        {
            case levelRange.IStar:
                break;
            case levelRange.IIStars:
                break;
            case levelRange.IIIStars:
                break;
            case levelRange.IVStars:
                break;
            case levelRange.VStars:
                break;
            case levelRange.VIStars:
                break;
            case levelRange.Master:
                break;
                
        }
        var creature = new CreatureRaw();
        
    }
    private static CreatureTemplate GetCreatureTemplate(int index) 
    {
        return Zoo.zoo.Creature(index);
    }
}
