using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public platformType type;
    public WorldManager worldManager;
    public EntityStats enemy;
    public GameObject MonsterToSpawn;
    public int monsterID;

    [SerializeField] GameObject enemyVisual;

    public bool killed;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {


        if (killed)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            enemyVisual.SetActive(false);
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveInfo()
    {
        worldManager.monsterToSpawn = MonsterToSpawn;
        worldManager.currentEnemy = enemy;
        worldManager.MonsterID = monsterID;

    }
}
