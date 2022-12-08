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

    [HideInInspector] public int currentArmor;
    [HideInInspector] public int maxArmor;


    [SerializeField] SpriteRenderer swordSprite;
    public Animator anim;

    [SerializeField] AudioClip[] hurt;
    [SerializeField] AudioClip core, armor;


    public AudioClip slash;
    public bool takeDamage(int damage)
    {
        if(currentArmor > 0)
        {
            currentArmor -= damage;
            AudioManager.playSound(armor, .7f);

        }
        else
        {
            currentHP -= damage;
            AudioManager.playSound(core, .7f);

        }
        if (currentArmor < 0)
        {
            currentArmor = 0;
        }

        AudioManager.playSound(hurt[Random.Range(0, hurt.Length)], .5f);

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
        maxArmor = Mathf.RoundToInt(stats.defence * (stats.upgradeDEF + 1));
        currentArmor = maxArmor;
    }

    public void attack(bool attacking)
    {
        anim.SetBool("Attacking", attacking);
    }

 



}
