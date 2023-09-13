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
        MapModificator.SelectTile();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) { ModifyMap(); }
    }
}
