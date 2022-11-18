using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI goldTxt, killsTxt, DayTxt, DMGTxt, DEFTxt, HPTxt, LevelTxt, NameTxt;
    [SerializeField] Slider levelBar;

    [SerializeField] int currentXP;
    [SerializeField] int levelRequried;

    [SerializeField] PlayerEntity playerStats;
     Weapon WeaponStats;

    // Start is called before the first frame update
    void Start()
    {
        WeaponStats = playerStats.weapon;

        levelBar.maxValue = levelRequried;
        setHud();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponStats = playerStats.weapon;
        DMGTxt.text = "DMG: " + WeaponStats.weaponDamage.x.ToString() + " - " + WeaponStats.weaponDamage.y.ToString();

    }

    public void setHud() 
    {
        currentXP = playerStats.currentXP;



        goldTxt.text = "Gold: " + playerStats.gold.ToString();
        killsTxt.text = "Kills: " + playerStats.kills.ToString();
        DayTxt.text = "Day: " + playerStats.day.ToString();
        DMGTxt.text = "DMG: " + WeaponStats.weaponDamage.x.ToString() + " - " + WeaponStats.weaponDamage.y.ToString();
        DEFTxt.text = "DEF: " + playerStats.defence.ToString();
        HPTxt.text = "HP: " + playerStats.health.ToString();
        LevelTxt.text = "Level: " + playerStats.level.ToString();
        NameTxt.text = playerStats.PlayerName.ToString();
        levelBar.value = playerStats.currentXP;

    }
}
