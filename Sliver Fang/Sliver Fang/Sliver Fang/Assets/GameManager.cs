using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpriteRenderer swordSpriteRenderer;
    public PlayerEntity playerEntity;

    private void Awake()
    {
        swordSpriteRenderer.sprite = playerEntity.weapon.weaponSprite;

}
void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        swordSpriteRenderer.sprite = playerEntity.weapon.weaponSprite;

    }
}
