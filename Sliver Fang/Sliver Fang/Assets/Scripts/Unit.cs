using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public EntityStats stats;
    public Weapon weapon;

    [HideInInspector] public string unitName;
    [HideInInspector] public int unitLevel;
    [HideInInspector] public Vector2 damage;

    [HideInInspector] public int maxHP;
    [HideInInspector] public int currentHP;

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
        unitName = stats.EntityName;
        unitLevel = stats.level;
        damage = weapon.weaponDamage;
        maxHP = stats.health;
        currentHP = maxHP;
    }

}
