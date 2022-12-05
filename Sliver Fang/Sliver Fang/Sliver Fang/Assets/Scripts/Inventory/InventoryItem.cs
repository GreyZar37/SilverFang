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
    [SerializeField] AudioClip EquipSound, DropSound;

    public Weapon weapon;
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
        AudioManager.playSound(EquipSound, 1f);
    }
    void drop()
    {
      
            InventoryManager.iventoryID.Remove(weapon.weaponID);
            Destroy(gameObject);
        AudioManager.playSound(DropSound, 1f);

    }
}
