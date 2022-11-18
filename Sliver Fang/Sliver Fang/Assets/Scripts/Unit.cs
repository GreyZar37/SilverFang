using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public EntityStats stats;

    [HideInInspector] public string unitName;
    [HideInInspector] public int unitLevel;
    [HideInInspector] public Vector2 damage;

    [HideInInspector] public int maxHP;
    [HideInInspector] public int currentHP;

    [HideInInspector] public int xpToGive;
    [HideInInspector] public int Gold;


    private void Start()
    {
    }
   
    public bool takeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP<= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setStats()
    {
        unitName = stats.EnemyName;
        unitLevel = stats.level;
        damage = stats.damage;
        maxHP = stats.health;
        currentHP = maxHP;
        Gold = stats.goldToGive;
        xpToGive = stats.xpToGive;


    }

}
