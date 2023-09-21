using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    public static Zoo zoo;

    [SerializeField] private CreatureTemplate[] _creatures;
    public CreatureTemplate Creature(int index) { return _creatures[index]; }
    private void InitializeMe()
    {
        zoo = this;
    }
    private void Awake()
    {
        InitializeMe();
    }
}
