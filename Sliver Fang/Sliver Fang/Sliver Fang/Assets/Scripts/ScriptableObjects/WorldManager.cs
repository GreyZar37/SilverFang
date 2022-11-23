using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class WorldManager : ScriptableObject
{

    public int currentLocation;

    public GameObject monsterToSpawn;
    public EntityStats stats;

    public List<string> enemiesDeafeted = new List<string>();
    
    public void gameDone()
    {
        monsterToSpawn = null;


    }
}
