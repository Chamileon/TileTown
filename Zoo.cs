using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    public static Zoo zoo;

     

    private void InitializeMe()
    {
        if (zoo == null) zoo = this; else Destroy(gameObject);
    }
    private void Awake()
    {
        InitializeMe();
    }
}
