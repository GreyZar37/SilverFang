using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI goldTxt, killsTxt, DayTxt, DMGTxt, DEFTxt, HPTxt, LevelTxt, NameTxt, engText;
    [SerializeField] Slider levelBar, engBar;

    int currentXP;
    int xpRequired;

    [SerializeField] PlayerEntity playerStats;
     Weapon WeaponStats;


    // Start is called before the first frame update
    void Start()
    {
        WeaponStats = playerStats.weapon;

        setHud();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            print(Random.Range(0, 3));
        }
        WeaponStats = playerStats.weapon;


        int EngBarBloodMaxValue = Mathf.RoundToInt(playerStats.BloodMaxValue * (playerStats.upgradeENG + 1));
        int HPValue = Mathf.RoundToInt(playerStats.health * (playerStats.upgradeHP + 1));
        int DMGx = Mathf.RoundToInt(WeaponStats.weaponDamage.x * (playerStats.upgradeDMG + 1));
        int DMGy = Mathf.RoundToInt(WeaponStats.weaponDamage.y * (playerStats.upgradeDMG + 1));


        engBar.maxValue = EngBarBloodMaxValue;
        engBar.value = playerStats.currentBlood;

        engText.text = playerStats.currentBlood.ToString() + "/" + EngBarBloodMaxValue.ToString();
        DMGTxt.text = "DMG: " + DMGx.ToString() + " - " + DMGy.ToString();
        DEFTxt.text = "DEF: " + playerStats.defence.ToString();
        HPTxt.text = "HP: " + HPValue.ToString();
        goldTxt.text = "Gold: " + playerStats.gold.ToString();

        level();
    }

    public void setHud()
    {
 
        killsTxt.text = "Kills: " + playerStats.kills.ToString();
        DayTxt.text = "Day: " + playerStats.day.ToString();
   
        NameTxt.text = playerStats.PlayerName.ToString();

    
    }

    void level()
    {
        xpRequired = playerStats.XpRequired;
        levelBar.maxValue = xpRequired;
        currentXP = playerStats.currentXP;

        LevelTxt.text = "Level: " + playerStats.level.ToString();
        levelBar.value = playerStats.currentXP;

    }
}
