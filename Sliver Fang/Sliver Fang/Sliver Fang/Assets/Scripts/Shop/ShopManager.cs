using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ShopManager : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI playerGold;
    [SerializeField] Button refreshBtn;

    [SerializeField] PlayerEntity playerStats;

    List<GameObject> weaponsInShop = new List<GameObject>();



    [SerializeField] List<Weapon> weaponsToSpawn = new List<Weapon>();
    [SerializeField] List<Weapon> Weapons = new List<Weapon>();

    [SerializeField] GameObject item;
    [SerializeField] Transform itemHolder;

    [SerializeField] GameObject adUI;

    [SerializeField] AudioClip buttonClickSound;


    bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {

        refreshWeapons();
        refreshBtn.onClick.AddListener(() => refreshWeapons());
    }

    // Update is called once per frame
    void Update()
    {
        playerGold.text = "Gold: " + playerStats.gold;

    }


    void refreshWeapons()
    {

        weaponsToSpawn.AddRange(Weapons);

        for (int i = 0; i < weaponsInShop.Count; i++)
        {
            Destroy(weaponsInShop[i].gameObject);
        }
        weaponsInShop.Clear();

        for (int i = 0; i < 4; i++)
        {
            GameObject weapon = Instantiate(item, itemHolder);
            weaponsToSpawn.Remove(weapon.GetComponent<itemScript>().weapon = weaponsToSpawn[Random.Range(0, weaponsToSpawn.Count)]);
            weaponsInShop.Add(weapon);
        }

        if(firstTime == false)
        {
            AudioManager.playSound(buttonClickSound, 1f);
            StartCoroutine(ad());
        }
        else
        {
            firstTime =  false;
        }
      
    }
    IEnumerator ad()
    {
        adUI.SetActive(true);

        yield return new WaitForSeconds(40);
        adUI.SetActive(false);

    }

}
