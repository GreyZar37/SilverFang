using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public PlayerEntity player;

  

    // Update is called once per frame
    void Update()
    {
        if (player.currentXP >= player.XpRequired)
        {
            player.currentXP -= player.XpRequired;
            player.level++;
            player.XpRequired += (int)(player.XpRequired * 0.25f);
            player.upgradePoints++;
        }
    }
}
