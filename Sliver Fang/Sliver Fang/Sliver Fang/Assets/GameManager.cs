using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpriteRenderer swordSpriteRenderer;
    public PlayerEntity playerEntity;

    public static bool battleEnded;
    [SerializeField] GameObject coins;
    [SerializeField] Transform player;

    private void Awake()
    {
        swordSpriteRenderer.sprite = playerEntity.weapon.weaponSprite;

}
void Start()
    {
        if(battleEnded == true)
        {
            for (int i = 0; i < Random.Range(5, 20); i++)
            {
                Instantiate(coins, player.position, Quaternion.Euler(0, 0, Random.Range(-45, 45)));

            }
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
}
