using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class itemScript : MonoBehaviour
{
    [SerializeField] Image weaponImage;
    [SerializeField] TextMeshProUGUI Price, stats, weaponName;
    [SerializeField] Button buyBtn;

    public Weapon weapon;
    [SerializeField] PlayerEntity playerStats;

    // Start is called before the first frame update
    void Start()
    {
        giveStats();
        buyBtn.onClick.AddListener(() => buyItem());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void giveStats()
    {
        Price.text = "Gold: " + weapon.price;
        stats.text = "Dmg: " + weapon.weaponDamage.x + "-" + weapon.weaponDamage.y;
        weaponName.text = weapon.weaponName;
        weaponImage.sprite = weapon.weaponSprite;
    }

    public void buyItem()
    {
        if(playerStats.gold >= weapon.price)
        {
            InventoryManager.iventoryID.Add(weapon.weaponID);
            playerStats.gold -= weapon.price;
            Destroy(gameObject);
        }

    }

}
