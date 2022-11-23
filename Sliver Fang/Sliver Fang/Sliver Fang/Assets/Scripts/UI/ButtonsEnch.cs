using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsEnch : MonoBehaviour
{
    public ParticleSystem selectedPlay;
    public bool selected;
    public string enchantment;
    public int bloodCost;

    public Combat unit;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enchant()
    {
        if (selected)
        {
            unit.playerUnit.currentBlood += bloodCost;

            selectedPlay.Stop();
            unit.enchantmentList.Remove(enchantment);
            selected = false;

        }
        else if(!selected && unit.playerUnit.currentBlood >= bloodCost)
        {
            unit.playerUnit.currentBlood -= bloodCost;

            selectedPlay.Play();
            unit.enchantmentList.Add(enchantment);
            selected = true;
        }
        anim.SetBool("Selected", selected);
        unit.playerHud.StaminaSlider.value = unit.playerUnit.currentBlood;
        unit.playerHud.StaminaText.text = unit.playerUnit.currentBlood.ToString() + "/" + unit.playerUnit.BloodMeter.ToString();


    }

    public void submit()
    {
        selectedPlay.Stop();
        unit.enchantmentList.Remove(enchantment);
        selected = false;
        anim.SetBool("Selected", selected);

    }


}
