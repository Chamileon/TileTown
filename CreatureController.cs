using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    [SerializeField] private CreatureRaw _creature;
    public CreatureRaw Creature { get { return _creature; } set { _creature = value; } }
}
