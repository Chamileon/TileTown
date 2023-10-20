using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(God))]


public class CreatureSpawner : MonoBehaviour
{
    public static CreatureSpawner spawner;
    [SerializeField] private GameObject creaturePrefab;
    [SerializeField] private int obIndex;
    public int INDEX { get => obIndex;  set => obIndex = value; }
    [SerializeField] private int creatureLevel;
    public static GameObject lastThingGenerated;
    [SerializeField] private bool activated;
    public bool ACTIVATED { get => activated; set => activated = value; }
    private void Awake()
    {
        spawner = this;
        lastThingGenerated = null;
    }
    public void SpawnAStructure(int index) { }
    public void SpawnAnEvent(int index) { }
    public void SpawnNPC(int index) { }
    public void Spawn(int mode) 
    {
        switch (mode) 
        {
            case 0:
                SpawnACreatureOverPointer(obIndex, creatureLevel);
                break;
            case 1:
                SpawnNPC(obIndex);
                break;
            case 2:
                SpawnAStructure(obIndex);
                break;
            case 3:
                SpawnAnEvent(obIndex);
                break;
        }
    }
    public GameObject SpawnACreatureInATile(int index, int lvl, int x, int y)
    {
        Vector3 spawnPos = new Vector3(x + .5f, y + .5f, 0);
        GameObject go = Instantiate(creaturePrefab, spawnPos, Quaternion.identity);
        Debug.Log(go);
        CreatureController cc = go.GetComponent<CreatureController>();
        cc.CREATURE.CreatureTemplate = Zoo.zoo.Creature(index);
        cc.CREATURE.SetLvl(creatureLevel);
        lastThingGenerated = go;
        Tile t = MapModificator.SelectTile();
        t.onMe = go;
        t.Properties.occupied = true;
        t.Properties.objectType = 0;
        t.Properties.objectID = index;
        return go;

    }
    public GameObject SpawnThisCreatureInATile(CreatureRaw creatureIn, int x, int y)
    {
        Vector3 spawnPos = new Vector3(x + .5f, y + .5f, 0);
        GameObject go = Instantiate(creaturePrefab, spawnPos, Quaternion.identity);
        Debug.Log(go);
        CreatureController cc = go.GetComponent<CreatureController>();
        cc.CREATURE = creatureIn;
        lastThingGenerated = go;
        Tile t = MapModificator.SelectTile();
        t.onMe = go;
        t.Properties.occupied = true;
        return go;

    }
    public void SpawnACreatureOverPointer(int index, int lvl)
    {
        Vector3 spawnPos = God.SpawnPosition;
        GameObject go = Instantiate(creaturePrefab, spawnPos, Quaternion.identity);
        Debug.Log(go);
        CreatureController cc = go.GetComponent<CreatureController>();
        cc.CREATURE.CreatureTemplate = Zoo.zoo.Creature(index);
        cc.CREATURE.SetLvl(creatureLevel);
        lastThingGenerated = go;
        Tile t = MapModificator.SelectTile();
        t.onMe = go;
        t.Properties.occupied = true;
        t.Properties.objectType = 0;
        t.Properties.objectID = index;

    }
    private void InvokeMe() 
    {
        if (spawner != null && Input.GetKeyUp(KeyCode.S) && !EventSystem.current.IsPointerOverGameObject())
        {
            SpawnACreatureOverPointer(obIndex, creatureLevel);
            Debug.Log("Spawned");
        }
    }
    private void Update()
    {
        if(ACTIVATED)InvokeMe();
    }
}
