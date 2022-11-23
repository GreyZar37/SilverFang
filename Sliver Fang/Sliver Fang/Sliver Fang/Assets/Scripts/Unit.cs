using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public EntityStats stats;

    [HideInInspector] public string unitName;
    [HideInInspector] public Vector2 unitLevel;
    [HideInInspector] public Vector2 damage;

    [HideInInspector] public int maxHP;
    [HideInInspector] public int currentHP;

    [HideInInspector] public int xpToGive;
    [HideInInspector] public int Gold;

    [HideInInspector] public int hitInfo;

    public SpriteRenderer enemyVisual;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //enemyVisual.GetComponent<SpriteRenderer>().sprite = stats.enemyVisual;

    }
  

    public bool takeDamage(int damage, EnchantmentType enchahntment)
    {

        switch (stats.enemyType)
        {
            case enemyType.NormalVampyr:
                switch (enchahntment)
                {
                    case EnchantmentType.BloodyWater:
                         currentHP += damage * 2;
                        hitInfo = damage * 2;
                        break;
                    case EnchantmentType.MysteriousStew:
                        currentHP -= damage * 3;
                        hitInfo = damage * 3;
                        break;
                    case EnchantmentType.BloodyGarlic:
                        currentHP -= damage / 2;
                        hitInfo = damage / 2;
                        break;
                    case EnchantmentType.GarlicStew:
                        currentHP -= damage * 2;
                        hitInfo = damage * 2;
                        break;
                    case EnchantmentType.Garlic:
                        currentHP -= (int)(damage * 1.25f);
                        hitInfo = (int)(damage * 1.25f);

                        break;
                    case EnchantmentType.Blood:
                        currentHP += damage;
                        hitInfo = damage;
                        break;
                    case EnchantmentType.HolyWater:
                        currentHP -= (int)(damage * 1.5f);
                        hitInfo = (int)(damage * 1.5f);

                        break;
                    case EnchantmentType.noEffect:
                         currentHP -= damage;
                        hitInfo = (int)(damage * 1.5f);

                        break;
                    default:
                        break;
                }
                break;
            case enemyType.GreatVampyr:
                switch (enchahntment)
                {
                    case EnchantmentType.BloodyWater:
                        break;
                    case EnchantmentType.MysteriousStew:
                        break;
                    case EnchantmentType.BloodyGarlic:
                        break;
                    case EnchantmentType.GarlicStew:
                        break;
                    case EnchantmentType.Garlic:
                        break;
                    case EnchantmentType.Blood:
                        break;
                    case EnchantmentType.HolyWater:
                        break;
                    case EnchantmentType.noEffect:
                        break;
                    default:
                        break;
                }
                break;
            case enemyType.LegacyVampyr:
                switch (enchahntment)
                {
                    case EnchantmentType.BloodyWater:
                        break;
                    case EnchantmentType.MysteriousStew:
                        break;
                    case EnchantmentType.BloodyGarlic:
                        break;
                    case EnchantmentType.GarlicStew:
                        break;
                    case EnchantmentType.Garlic:
                        break;
                    case EnchantmentType.Blood:
                        break;
                    case EnchantmentType.HolyWater:
                        break;
                    case EnchantmentType.noEffect:
                        break;
                    default:
                        break;
                }
                break;
            case enemyType.NormalWereWolf:
                switch (enchahntment)
                {
                    case EnchantmentType.BloodyWater:
                        break;
                    case EnchantmentType.MysteriousStew:
                        break;
                    case EnchantmentType.BloodyGarlic:
                        break;
                    case EnchantmentType.GarlicStew:
                        break;
                    case EnchantmentType.Garlic:
                        break;
                    case EnchantmentType.Blood:
                        break;
                    case EnchantmentType.HolyWater:
                        break;
                    case EnchantmentType.noEffect:
                        break;
                    default:
                        break;
                }
                break;
            case enemyType.TerrorWereWolf:
                switch (enchahntment)
                {
                    case EnchantmentType.BloodyWater:
                        break;
                    case EnchantmentType.MysteriousStew:
                        break;
                    case EnchantmentType.BloodyGarlic:
                        break;
                    case EnchantmentType.GarlicStew:
                        break;
                    case EnchantmentType.Garlic:
                        break;
                    case EnchantmentType.Blood:
                        break;
                    case EnchantmentType.HolyWater:
                        break;
                    case EnchantmentType.noEffect:
                        break;
                    default:
                        break;
                }
                break;
            case enemyType.AlphaWerewolf:
                switch (enchahntment)
                {
                    case EnchantmentType.BloodyWater:
                        break;
                    case EnchantmentType.MysteriousStew:
                        break;
                    case EnchantmentType.BloodyGarlic:
                        break;
                    case EnchantmentType.GarlicStew:
                        break;
                    case EnchantmentType.Garlic:
                        break;
                    case EnchantmentType.Blood:
                        break;
                    case EnchantmentType.HolyWater:
                        break;
                    case EnchantmentType.noEffect:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }


        if(currentHP<= 0)
        {
            currentHP = 0;
            return true;
        }
        else if(currentHP > maxHP)
        {
            currentHP = maxHP;
            return false;

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
        Gold =stats.goldToGive;
        xpToGive = stats.xpToGive;


    }


}
