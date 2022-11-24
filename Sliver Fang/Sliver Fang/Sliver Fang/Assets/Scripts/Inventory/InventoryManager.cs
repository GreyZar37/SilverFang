using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static List<string> iventoryID = new List<string>();
    [SerializeField] Transform itemTransform;

    [SerializeField] List<Weapon> weaponLibrary = new List<Weapon>();

    [SerializeField] List<GameObject> weaponsInventory = new List<GameObject>();

    [SerializeField] GameObject weaponItems;
    [SerializeField] GameObject InventoryUI;

    [SerializeField] Button inventoryButtonOpen;
    [SerializeField] Button inventoryButtonClose;


    private void Update()
    {
    }
    private void Start()
    {
        inventoryButtonOpen.onClick.AddListener(() => OpenOrClose());
        inventoryButtonClose.onClick.AddListener(() => close());

    }
    public void OpenOrClose()
    {
      
            InventoryUI.SetActive(true);
            for (int i = 0; i < iventoryID.Count; i++)
            {
                GameObject weapon = Instantiate(weaponItems, itemTransform);
                weaponsInventory.Add(weapon);

                switch (iventoryID[i])
                {
                    case "1.1.0":
                        weapon.GetComponent<InventoryItem>().weapon = weaponLibrary[0];
                        print("dd");

                        break;
                    case "1.2.0":
                        weapon.GetComponent<InventoryItem>().weapon = weaponLibrary[1];
                        break;
                    case "1.3.0":
                        weapon.GetComponent<InventoryItem>().weapon = weaponLibrary[2];
                        break;
                    case "1.4.0":
                        weapon.GetComponent<InventoryItem>().weapon = weaponLibrary[3];

                        break;

                    default:
                        break;
                }
            }
        
      
       
    }

    public void close()
    {
        InventoryUI.SetActive(false);
        for (int i = 0; i < weaponsInventory.Count; i++)
        {
            Destroy(weaponsInventory[i].gameObject);
        }
        weaponsInventory.Clear();
    }

}
