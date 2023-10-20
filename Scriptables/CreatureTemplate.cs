using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(menuName = "Create Creature Template",fileName = "New Creature")]
public class CreatureTemplate : ScriptableObject
{
    
    [Header("Basic Info")]
    public new string name;
    [TextArea(3,20)]
    public string description;
    public CreatureType type;
    public bool canBeRecluted, canBeEvolutioned;
    [HideInInspector]public int levelToEvolution;

    
    

    public CreatureElement[] elements;
    [Header("Creature Status")]
    [Range(0, 10)] public int basicHealth;
    [Range(0, 10)] public int basicMana;
    [Range(0, 10)] public int basicAttack;
    [Range(0, 10)] public int basicDefense;
    [Range(0, 10)] public int basicMagicAttack;
    [Range(0, 10)] public int basicMagicDefense;
    [Range(0, 10)] public int basicRange;
}
public class CreatureTemplateEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Debug.Log("HOla worlddd");
        CreatureTemplate template = (CreatureTemplate)target;
        EditorGUILayout.BeginVertical();
        template.canBeEvolutioned = EditorGUILayout.Toggle("Can Be Evolutioned", template.canBeEvolutioned);
        if (template.canBeEvolutioned)
        {
            template.levelToEvolution = EditorGUILayout.IntField("Level to Evolution", template.levelToEvolution);
        }
        EditorGUILayout.EndVertical();
        base.OnInspectorGUI();

    }

}
public enum CreatureType { D = 10, C = 20, B = 30, A = 40, Z = 50, Legendary = 60, Acient = 70}
public enum CreatureElement { Water , Plant, Fire, Air, Ground, Electric, Ice, Light, Dark, Poison}
