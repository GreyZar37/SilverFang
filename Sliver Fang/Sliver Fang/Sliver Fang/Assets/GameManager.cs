using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpriteRenderer swordSpriteRenderer;
    public PlayerEntity playerEntity;
    
    public static int coinsToSpawn;
    public static int xpToSpawn;

    public static bool battleEnded;
    [SerializeField] GameObject coins, xp;
    [SerializeField] Transform player;

    private void Awake()
    {
        swordSpriteRenderer.sprite = playerEntity.weapon.weaponSprite;

}
void Start()
    {
        if(battleEnded == true)
        {
            StartCoroutine(spawnCoins());
            StartCoroutine(spawnXp());
        }
        else
        {
            battleEnded = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        swordSpriteRenderer.sprite = playerEntity.weapon.weaponSprite;

    }

    IEnumerator spawnCoins()
    {
        int i = 0;
        yield return new WaitForSeconds(0.5f);

        while (coinsToSpawn > i)
        {

            i++;
            Instantiate(coins, player.position, Quaternion.Euler(0, 0, Random.Range(-45, 45)));
            yield return new WaitForSeconds(0.05f);

        }

    }
    IEnumerator spawnXp()
    {
        int i = 0;
        yield return new WaitForSeconds(0.7f);

        while (xpToSpawn > i)
        {

            i++;
            Instantiate(xp, player.position, Quaternion.Euler(0, 0, Random.Range(-45, 45)));
            yield return new WaitForSeconds(0.05f);

        }

    }

}
