using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Entity/Stats/Enemy")]

public class EntityStats : ScriptableObject
{
    public Sprite enemyVisual;

    public string EnemyName;
    public int goldToGive, defence ,health, level, xpToGive;
    public Vector2 damage;

}




