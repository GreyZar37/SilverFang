using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Platform : MonoBehaviour
{
    public platformType type;
    public WorldManager worldManager;



    [Header("EnemyPlatform")]
    public EntityStats stats;
    public GameObject MonsterToSpawn;
    public string monsterID;
    [SerializeField] GameObject enemyVisual;
    public bool killed;


    [Header("ShopPlatform")]

    [SerializeField] GameObject ShopCanvasUI;
    [SerializeField] GameObject StatsUI;
    Animator animator;

    [Header("TreasurePlatform")]
    public PlayerEntity playerMoney;
    public int coins;
    public GameObject coinsPrefab;
    public ParticleSystem coinsRain;

    public SpriteRenderer chestCap;
    public Sprite openCap;



    // Start is called before the first frame update
    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>();
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
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveInfo()
    {
        worldManager.monsterToSpawn = MonsterToSpawn;
        worldManager.stats = stats;
        worldManager.enemiesDeafeted.Add(monsterID);

    }

    public void openShop()
    {
        animator.SetTrigger("Fade");

        StatsUI.SetActive(false);
        ShopCanvasUI.SetActive(true);
    }
    public void openChest()
    {
        coinsRain.Play();
        GameObject spawned = Instantiate(coinsPrefab, transform.position, Quaternion.identity);
        spawned.GetComponent<TextMeshPro>().text = coins.ToString();
        playerMoney.gold += coins;
        chestCap.sprite = openCap;
    }
}
