using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum levelRange { IStar = 10, IIStars = 20, IIIStars = 30, IVStars = 40, VStars = 50, VIStars = 60, Master = 80, Legend = 100  }
public static class CreatureFactory
{
    public static CreatureRaw NewCreature(levelRange range, CreatureElement element)
    {
        CreatureTemplate ct;

        switch (range) 
        {
            case levelRange.IStar:
                 ct = Zoo.zoo.CreatureRandom(CreatureType.A, element);
                break;
            case levelRange.IIStars:
                ct = Zoo.zoo.CreatureRandom(CreatureType.B, element);
                break;
            case levelRange.IIIStars:
                ct = Zoo.zoo.CreatureRandom(CreatureType.C, element);
                break;
            case levelRange.IVStars:
                ct = Zoo.zoo.CreatureRandom(CreatureType.D, element);
                break;
            case levelRange.VStars:
                ct = Zoo.zoo.CreatureRandom(CreatureType.Z, element);
                break;
            case levelRange.VIStars:
                ct = Zoo.zoo.CreatureRandom(CreatureType.Legendary, element);
                break;
            case levelRange.Master:
                ct = Zoo.zoo.CreatureRandom(CreatureType.Acient, element);
                break;
            default: ct = Zoo.zoo.CreatureRandom();
                break;


        }
        var creature = new CreatureRaw(ct,Random.Range(0,(int) range));
        return creature;
        
    }

    
}
