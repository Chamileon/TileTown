using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapModificatorController : MonoBehaviour
{
    public static MapModificatorController modController;
    public static Tile actualtile;
    [SerializeField] private UpOrDown _modificatorMode;
    [SerializeField] [Range(0, 0)] private int _bioma;
    [SerializeField] [Range(0,9)] private int _newlvl;
    private void Awake()
    {

        modController = this;
        _modificatorMode = UpOrDown.None;
    }
    public void ModifyMap() 
    {
        MapModificator.ModifyTile(_modificatorMode, _newlvl, _bioma);
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject()) { ModifyMap(); actualtile = MapModificator.SelectTile(); }
    }
}
