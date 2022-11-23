using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Weapons/Swords")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public int price;
    public Vector2 weaponDamage;
    public Sprite weaponSprite;

    public string weaponID;
}
