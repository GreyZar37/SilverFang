using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class WorldManager : ScriptableObject
{
    public EntityStats currentEnemy;
    public int MonsterID;

    public int currentLocation;

    public GameObject monsterToSpawn;
    
    public void gameDone()
    {
        currentEnemy = null;
        monsterToSpawn = null;


    }
}
