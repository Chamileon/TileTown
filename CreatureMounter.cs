using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CreatureMounter : MonoBehaviour
{
    public static  CreatureMounter Mounter;
    public static GameObject MountCreature(levelRange range, CreatureElement element) 
    {
        var creature = CreatureFactory.NewCreature(range, element);
        GameObject go = new GameObject();
        CreatureController cc = go.AddComponent<CreatureController>();
        cc.Creature = creature;

        /////////hhhhhhhhhhhhhhhhhhhhhhhhh//////////////////
        GameObject Mounted = Instantiate(go, MapModificator.WorldPosition(), Quaternion.identity);
        return Mounted;
    }
    private void Awake()
    {
        Mounter = this;
    }

}
