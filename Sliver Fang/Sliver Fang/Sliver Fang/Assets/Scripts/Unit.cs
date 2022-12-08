using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [HideInInspector] public EntityStats stats;

    [HideInInspector] public string unitName;
    [HideInInspector] public Vector2 unitLevel;
    [HideInInspector] public Vector2 damage;

    [HideInInspector] public int maxHP;
    [HideInInspector] public int currentHP;

    [HideInInspector] public int maxArmor;
    [HideInInspector] public int currentArmor;

    [HideInInspector] public int xpToGive;
    [HideInInspector] public int Gold;

    [HideInInspector] public int hitInfo;

    public Sprite enemyVisual;
    [HideInInspector] public Animator animator;
    [SerializeField] AudioClip core, armor;

    private void Start()
    {
        animator = GetComponent<Animator>();

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

                        if(currentArmor > 0)
                        {
                            currentArmor -= damage * 2;
                            hitInfo = damage * 2;

                        }
                        else
                        {
                            currentHP -= damage * 3;
                            hitInfo = damage * 3;
                        }

                        break;
                    case EnchantmentType.BloodyGarlic:

                        if (currentArmor > 0)
                        {
                            currentArmor -= damage * 3;
                            hitInfo = damage * 3;

                        }
                        else
                        {
                            currentHP -= damage / 2;
                            hitInfo = damage / 2;
                        }

                        break;
                    case EnchantmentType.GarlicStew:

                        if (currentArmor > 0)
                        {
                            currentArmor -= damage /2;
                            hitInfo = damage/2;

                        }
                        else
                        {

                            currentHP -= Mathf.RoundToInt(damage * 2.5f);
                            hitInfo = Mathf.RoundToInt(damage * 2.5f);
                        }

                        break;
                    case EnchantmentType.Garlic:
                        if (currentArmor > 0)
                        {
                            currentArmor -= damage * 2;
                            hitInfo = damage * 2;

                        }
                        else
                        {
                            currentHP -= Mathf.RoundToInt(damage * 1.5f);
                            hitInfo = Mathf.RoundToInt(damage * 1.5f);
                        }

                        break;
                    case EnchantmentType.Blood:
                        currentHP += damage;
                        hitInfo = damage;
                        break;
                    case EnchantmentType.HolyWater:

                        if (currentArmor > 0)
                        {
                            currentArmor -= damage;
                            hitInfo = damage;

                        }
                        else
                        {
                            currentHP -= Mathf.RoundToInt(damage * 2f);
                            hitInfo = Mathf.RoundToInt(damage * 2f);
                        }
                       

                        break;
                    case EnchantmentType.noEffect:

                        if (currentArmor > 0)
                        {
                            currentArmor -= damage;
                            hitInfo = damage;

                        }
                        else
                        {
                            currentHP -= damage;
                            hitInfo = damage;
                        }


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


        if (currentArmor <= 0)
        {
            AudioManager.playSound(core, .5f);

            currentArmor = 0;
        }
        else
        {
            AudioManager.playSound(armor, .7f);
        }

        if (currentHP<= 0)
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
        maxArmor = stats.defence;
        currentArmor = maxArmor;

    }


}
