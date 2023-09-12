using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModificatorController : MonoBehaviour
{
    public static MapModificatorController Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void ModifyMap() 
    {
        MapModificator.ModifyMap();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) { ModifyMap(); }
    }
}
