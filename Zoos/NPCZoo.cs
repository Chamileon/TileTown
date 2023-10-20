using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(God))]
public class NPCZoo : MonoBehaviour
{
    public static NPCZoo ZooNPC;
    [SerializeField] private NPCTemplate[] npcs;

    public NPCTemplate NPCByIndex(int index) { return npcs[index]; }
    private void Awake()
    {
        ZooNPC = this;
    }
    
}
