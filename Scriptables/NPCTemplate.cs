using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create NPCTemplate", fileName ="New NPC")]
public class NPCTemplate : ScriptableObject
{
    [Header("NPC Basics")]
    [SerializeField] private new string name;
    [Space]
    [SerializeField][TextArea(3, 20)] private string[] dialogue;
    [Space]
    [SerializeField][Range(0, 10)] private int mode = 0;
    [SerializeField] private bool enemy = false;
    [SerializeField] private CreatureRaw[] team;
}
