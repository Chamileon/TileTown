using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum levelRange { IStar, IIStars, IIIStars, IVStars, VStars, VIStars, Master, Legend}
public class God : MonoBehaviour
{
    public static God god;
    public static readonly int ChunkMagnitude = 10;
    [SerializeField] private bool _nextStepReady = false;
    public bool IsNextStepReady { get { return _nextStepReady; } set { _nextStepReady = value; } }

    public static Vector3 SpawnPosition { get { return new Vector3(Mathf.FloorToInt(MapModificator.WorldPosition().x) + 0.5f, Mathf.FloorToInt(MapModificator.WorldPosition().y) + 0.5f, 0); } }

    private void OnEnable()
    {
        if (god == null) { god = this; } else { Destroy(gameObject); }    
    } 

    public static levelRange RandomRange() 
    {
        int i = Mathf.Abs(Random.Range(0, 100) - Random.Range(0, 100));
        levelRange lvlrange = levelRange.IStar;
        if(i <= 10) { lvlrange = levelRange.IStar; }
        else if(i <= 20) { lvlrange = levelRange.IIStars; }
        else if(i <= 30) { lvlrange = levelRange.IIIStars; }
        else if(i <= 40) { lvlrange = levelRange.IVStars; } 
        else if(i <= 50) { lvlrange = levelRange.VStars; }
        else if(i <= 60) { lvlrange = levelRange.VIStars; }
        else if(i <= 80) { lvlrange = levelRange.Master; }
        else if(i < 100) { lvlrange = levelRange.Legend; }
        return lvlrange;

    }
    public static CreatureElement RandomElement()
    {
        int i = Mathf.Abs(Random.Range(0, 9) - Random.Range(0, 9));
        CreatureElement element = CreatureElement.Water;
        switch (i) 
        {
            case 0: element = CreatureElement.Water;
                break;
            case 1: element = CreatureElement.Plant;
                break;
            case 2: element = CreatureElement.Fire;
                break;
            case 3: element = CreatureElement.Air;
                break;
            case 4: element = CreatureElement.Ground;
                break;
            case 5: element = CreatureElement.Electric;
                break;
            case 6: element = CreatureElement.Ice;
                break;
            case 7: element = CreatureElement.Dark;
                break;
            case 8: element = CreatureElement.Light;
                break;
            case 9: element = CreatureElement.Poison;
                break;
        }
        return element;

    }
}
