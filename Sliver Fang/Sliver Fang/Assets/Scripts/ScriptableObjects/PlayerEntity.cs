using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Entity/Stats/Player")]

public class PlayerEntity : ScriptableObject
{




    public string PlayerName;
    public int gold, kills, day, defence, health, level, currentXP;
    public Weapon weapon;

}

