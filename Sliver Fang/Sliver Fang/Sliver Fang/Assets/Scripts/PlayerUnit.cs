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
   
    [HideInInspector] public int BloodMeter;
    [HideInInspector] public int currentBlood;

    [SerializeField] SpriteRenderer swordSprite;
    [SerializeField] Animator anim;

    [SerializeField] AudioClip[] hurt;

    public bool takeDamage(int damage)
    {
        currentHP -= damage;
        AudioManager.playSound(hurt[Random.Range(0, hurt.Length)], 1f);

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
        swordSprite.sprite = stats.weapon.weaponSprite;
        unitName = stats.PlayerName;
        unitLevel = stats.level;
        damage = stats.weapon.weaponDamage;
        maxHP = Mathf.RoundToInt(stats.health * (stats.upgradeHP + 1));
        currentHP = maxHP;
        BloodMeter = Mathf.RoundToInt(stats.BloodMaxValue * (stats.upgradeENG + 1));
        currentBlood = stats.currentBlood;
    }

    public void attack(bool attacking)
    {
        anim.SetBool("Attacking", attacking);
    }

 



}
