using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyType
{
    NormalVampyr, GreatVampyr, LegacyVampyr,
    NormalWereWolf, TerrorWereWolf, AlphaWerewolf
}

[CreateAssetMenu(menuName = "Scriptable Objects/Entity/Stats/Enemy")]

public class EntityStats : ScriptableObject
{
    public Sprite enemyVisual;

    public string EnemyName;
    public int goldToGive, defence ,health, xpToGive;
    public Vector2 damage, level;

     public enemyType enemyType;


}




