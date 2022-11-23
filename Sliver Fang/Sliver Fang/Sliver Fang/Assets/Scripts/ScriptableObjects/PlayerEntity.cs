using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Entity/Stats/Player")]

public class PlayerEntity : ScriptableObject
{




    public string PlayerName;
    public int gold, kills, day, defence, health, level, currentXP, XpRequired,BloodMaxValue, currentBlood, upgradePoints;


    public float upgradeHP, upgradeENG, upgradeDEF, upgradeDMG;
 

    public Weapon weapon;

    
}

