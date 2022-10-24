using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Entity/Stats")]

public class EntityStats : ScriptableObject
{
    public string EntityName;
    public int gold, kills, day, defence, health, level;
    public Vector2 damage;



}




