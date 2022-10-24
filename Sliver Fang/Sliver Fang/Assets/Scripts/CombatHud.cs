using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CombatHud : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelTxt;

    public Slider hpSlider;

    public void setHud(Unit unit)
    {
        nameText.text = unit.unitName;
        levelTxt.text = "Level: " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;


    }

    public void setHP(int hp)
    {
        hpSlider.value = hp;

    }
}
