using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] PlayerEntity player;
    [SerializeField] TextMeshProUGUI DMG_Txt, HP_Txt, ENG_Txt, DEF_Txt, PT_TXT;
    [SerializeField] Button DMG_Btn, HP_Btn, ENG_Btn, DEF_Btn;




    [SerializeField] GameObject notify;
    private void Start()
    {
        HP_Btn.onClick.AddListener(() => upgradeStat("HP"));
        DEF_Btn.onClick.AddListener(() => upgradeStat("DEF"));
        ENG_Btn.onClick.AddListener(() => upgradeStat("ENG"));
        DMG_Btn.onClick.AddListener(() => upgradeStat("DMG"));
        setHud();
    }

    private void Update()
    {
        PT_TXT.text = "PT: " + player.upgradePoints.ToString();

        if (player.upgradePoints > 0)
        {
            notify.SetActive(true);
        }
        else
        {
            notify.SetActive(false);
        }
    }

   
    void setHud()
    {
        HP_Txt.text = "HP: " + (player.upgradeHP * 100).ToString("F0") + "%";
        DMG_Txt.text = "DMG: " + (player.upgradeDMG * 100).ToString("F0") + "%";
        ENG_Txt.text = "ENG: " +( player.upgradeENG * 100).ToString("F0") + "%";
        DEF_Txt.text = "DEF: " + (player.upgradeDEF * 100).ToString("F0") + "%";
    }

    void upgradeStat(string upgrade)
    {
        if(player.upgradePoints > 0)
        {
            switch (upgrade)
            {
                case "HP":
                    player.upgradeHP += 0.10f;

                    break;
                case "DMG":
                    player.upgradeDMG += 0.05f;

                    break;
                case "ENG":
                    player.upgradeENG += 0.05f;
                    break;
                case "DEF":
                    player.upgradeDEF += 0.10f;
                    

                    break;
                default:
                    break;
            }
            player.upgradePoints--;
            setHud();
        }
       
    }

}
