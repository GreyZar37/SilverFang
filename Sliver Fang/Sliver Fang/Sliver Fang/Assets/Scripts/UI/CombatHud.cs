using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CombatHud : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelTxt;

    public TextMeshProUGUI HealthText, StaminaText, ArmorText;

    public Slider hpSlider, StaminaSlider, ArmorSlider;
    public Image portrait;

    private void Start()
    {
        
    }
    public void setHudUnit(Unit unit, int level)
    {
        nameText.text = unit.unitName;
        levelTxt.text = "Level: " + level;


        ArmorText.text = unit.currentArmor.ToString() + "/" + unit.maxArmor.ToString();
        HealthText.text = unit.currentHP.ToString() + "/" + unit.maxHP.ToString();

        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;

        ArmorSlider.maxValue = unit.maxArmor;
        ArmorSlider.value = unit.currentArmor;

        portrait.sprite = unit.enemyVisual;

    }
    public void setHudPlayer(PlayerUnit unit)
    {
        HealthText.text = unit.currentHP.ToString() + "/" + unit.maxHP.ToString();
        ArmorText.text = unit.currentArmor.ToString() + "/" + unit.maxArmor.ToString();


        nameText.text = unit.unitName;
        levelTxt.text = "Level: " + unit.unitLevel;

        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;

        ArmorSlider.maxValue = unit.maxArmor;
        ArmorSlider.value = unit.currentArmor;

        StaminaSlider.maxValue = unit.BloodMeter;
        StaminaSlider.value = unit.currentBlood;



        StaminaText.text = unit.currentBlood.ToString() + "/" + unit.BloodMeter.ToString();
    }


}
