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
        WeaponStats = playerStats.weapon;
       
        engBar.maxValue = playerStats.BloodMaxValue;
        engBar.value = playerStats.currentBlood;

        engText.text = playerStats.currentBlood.ToString() + "/" + playerStats.BloodMaxValue.ToString();
        DMGTxt.text = "DMG: " + WeaponStats.weaponDamage.x.ToString() + " - " + WeaponStats.weaponDamage.y.ToString();
        DEFTxt.text = "DEF: " + playerStats.defence.ToString();
        HPTxt.text = "HP: " + playerStats.health.ToString();
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
