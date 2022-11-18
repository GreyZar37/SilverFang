using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class InventoryItem : MonoBehaviour
{


    [SerializeField] Button Equip, Drop;
    [SerializeField] TextMeshProUGUI swordName, swordDamage;
    [SerializeField] Image SwordImage;

    [SerializeField] PlayerEntity player;


    public Weapon weapon;
    public PlayerInventory inventory;
    bool equipped;

    // Start is called before the first frame update
    void Start()
    {
        getInfo();

        Equip.onClick.AddListener(() => equip());
        Drop.onClick.AddListener(() => drop());

    }




    void getInfo()
    {
        swordName.text = weapon.weaponName;
        swordDamage.text = weapon.weaponDamage.x + "-" + weapon.weaponDamage.y + " DMG";
        SwordImage.sprite = weapon.weaponSprite;
    }
    void equip()
    {
        player.weapon = weapon;
    }
    void drop()
    {
      
            inventory.weaponId.Remove(weapon.weaponID);
            Destroy(gameObject);
       
    }
}
