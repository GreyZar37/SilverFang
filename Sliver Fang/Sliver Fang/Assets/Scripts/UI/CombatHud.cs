using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CombatHud : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelTxt;

    public TextMeshProUGUI HealthText, StaminaText;

    public Slider hpSlider, StaminaSlider;

    public void setHudUnit(Unit unit)
    {
        nameText.text = unit.unitName;
        levelTxt.text = "Level: " + unit.unitLevel;

        HealthText.text = unit.currentHP.ToString() + "/" + unit.maxHP.ToString();
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }
    public void setHudPlayer(PlayerUnit unit)
    {
        HealthText.text = unit.currentHP.ToString() + "/" + unit.maxHP.ToString();


        nameText.text = unit.unitName;
        levelTxt.text = "Level: " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

   
}
