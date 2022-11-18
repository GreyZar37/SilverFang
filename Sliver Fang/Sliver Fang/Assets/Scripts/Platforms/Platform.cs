using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public platformType type;
    public WorldManager worldManager;
    public GameObject MonsterToSpawn;
    public string monsterID;

    [SerializeField] GameObject enemyVisual;

    [SerializeField] GameObject ShopCanvasUI;
    [SerializeField] GameObject StatsUI;


    public bool killed;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        if(type == platformType.EnemyPlatform)
        {
            if (worldManager.enemiesDeafeted != null)
            {
                if (worldManager.enemiesDeafeted.Contains(monsterID))
                {
                    killed = true;
                }
            }


            if (killed)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                enemyVisual.SetActive(false);
                this.enabled = false;
            }
        }
        else if (type == platformType.shopPlatform)
        {

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveInfo()
    {
        worldManager.monsterToSpawn = MonsterToSpawn;
        worldManager.enemiesDeafeted.Add(monsterID);

    }

    public void openShop()
    {
        StatsUI.SetActive(false);
        ShopCanvasUI.SetActive(true);
    }
}
