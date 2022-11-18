using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public PlayerEntity stats;

    [HideInInspector] public string unitName;
    [HideInInspector] public int unitLevel;
    [HideInInspector] public Vector2 damage;

    [HideInInspector] public int maxHP;
    [HideInInspector] public int currentHP;

    [SerializeField] Animator anim;

    public bool takeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
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
        unitName = stats.PlayerName;
        unitLevel = stats.level;
        damage = stats.weapon.weaponDamage;
        maxHP = stats.health;
        currentHP = maxHP;
    }

    public void attack(bool attacking)
    {
        anim.SetBool("Attacking", attacking);
    }

}
