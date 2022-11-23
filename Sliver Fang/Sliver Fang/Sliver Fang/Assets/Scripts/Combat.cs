using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum EnchantmentType
{
    BloodyWater, MysteriousStew, BloodyGarlic, GarlicStew, Garlic, Blood, HolyWater, noEffect
}
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class Combat : MonoBehaviour
{
    bool playerIsDead;
    public PlayerEntity playerStats;

    public WorldManager WorldManager;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerStation;
    public Transform enemyStation;

    [HideInInspector] public PlayerUnit playerUnit;
    Unit enemyUnit;

    public CombatHud playerHud;
    public CombatHud enemyHud;

    public BattleState state;

    [SerializeField] TextMeshProUGUI dialogueTxt;
    [SerializeField] Button attackBtn;

    public List<string> enchantmentList;
    public ButtonsEnch[] enchButtons;

    public EnchantmentType currentEnchantment = EnchantmentType.noEffect;


    int enemyLevel;

    // Start is called before the first frame update
    void Start()
    {
        attackBtn.onClick.AddListener(() => onAttackButton());
        state = BattleState.START;


        StartCoroutine(SetupBattle());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator  SetupBattle()
    {
        GameObject playerInst = Instantiate(playerPrefab, playerStation.position, Quaternion.identity);
        playerUnit = playerInst.GetComponent<PlayerUnit>();
        playerUnit.setStats();

        GameObject enemyInst = Instantiate(WorldManager.monsterToSpawn, enemyStation.position, Quaternion.Euler(0,180,0));
        enemyUnit = enemyInst.GetComponent<Unit>();
        enemyUnit.stats = WorldManager.stats;
        enemyUnit.setStats();
        enemyLevel = (int)Random.Range(enemyUnit.stats.level.x, enemyUnit.stats.level.y);
        enemyLevelBased(enemyLevel);
        playerHud.setHudPlayer(playerUnit);
        enemyHud.setHudUnit(enemyUnit, enemyLevel);
        dialogueTxt.text = "You are fighting " + enemyUnit.unitName;

       

        yield return new WaitForSeconds(2);

        state = BattleState.PLAYERTURN;
        playerTurn();
    }

    IEnumerator playerAttack()
    {
        makeEnch();
        playerUnit.attack(true);
        int damage = (int)Random.Range(playerUnit.damage.x * (playerStats.upgradeDMG + 1), playerUnit.damage.y * (playerStats.upgradeDMG + 1));
        bool isDead = enemyUnit.takeDamage(damage,currentEnchantment);

        enemyHud.setHudUnit(enemyUnit, enemyLevel);

        if (currentEnchantment == EnchantmentType.noEffect && playerUnit.currentBlood < 100)
        {
            playerUnit.currentBlood += 25;
        }
        if (playerUnit.currentBlood > 100)
        {
            playerUnit.currentBlood = 100;
        }

        for (int i = 0; i < enchButtons.Length; i++)
        {
            enchButtons[i].submit();
        }
        ShakeScreen.isShaking = true;

        playerHud.setHudPlayer(playerUnit);
        currentEnchantment = EnchantmentType.noEffect;

        if(enemyUnit.hitInfo > 0)
        {
            dialogueTxt.text = "Hit: " + enemyUnit.hitInfo + " DMG";

        }
        else
        {
            dialogueTxt.text = "Healed: " + enemyUnit.hitInfo + " HP";

        }

        playerUnit.stats.currentBlood = playerUnit.currentBlood;

        state = BattleState.ENEMYTURN;

        yield return new WaitForSeconds(1f);
        playerUnit.attack(false);

        if (isDead)
        {
            state = BattleState.WON;
            endBattle();
        }
        else
        {
            StartCoroutine(enemyAttack());
        }

        
    }


    IEnumerator enemyAttack()
    {
        dialogueTxt.text = enemyUnit.unitName + " is attacking";
        yield return new WaitForSeconds(1);

        ShakeScreen.isShaking = true;

        enemyLogic();
        playerHud.setHudPlayer(playerUnit);
        enemyHud.setHudUnit(enemyUnit, enemyLevel); 

        yield return new WaitForSeconds(1);
        enemyUnit.animator.SetBool("Attacking", false);
        enemyUnit.animator.SetBool("Healing", false);


        if (playerIsDead)
        {
            state = BattleState.LOST;
            endBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            playerTurn();
        }
    }

    void endBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueTxt.text = "You won!";
            playerStats.gold += enemyUnit.Gold;
            playerStats.currentXP += enemyUnit.xpToGive;
            playerStats.kills++;
            playerStats.day++;


        }
        else if (state == BattleState.LOST)
        {
            dialogueTxt.text = "You lost!";
            playerStats.currentXP += Mathf.RoundToInt( enemyUnit.xpToGive / 4);
            playerStats.day++;


        }

     SceneManager.LoadScene(1);
     WorldManager.gameDone();
    }
    void playerTurn()
    {
        dialogueTxt.text = "Your turn";
    }


    void onAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(playerAttack());
    }

   void makeEnch()
    {
        if (enchantmentList.Contains("Onion") && enchantmentList.Contains("HolyWater") && enchantmentList.Contains("Blood"))
        {
            currentEnchantment = EnchantmentType.MysteriousStew;
        }
        else if (enchantmentList.Contains("Onion") && enchantmentList.Contains("HolyWater"))
        {
            currentEnchantment = EnchantmentType.GarlicStew;

        }
        else if (enchantmentList.Contains("Onion") && enchantmentList.Contains("Blood"))
        {
            currentEnchantment = EnchantmentType.BloodyGarlic;

        }
        else if (enchantmentList.Contains("Blood") && enchantmentList.Contains("HolyWater"))
        {
            currentEnchantment = EnchantmentType.BloodyWater;

        }
        else if (enchantmentList.Contains("Blood"))
        {
            currentEnchantment = EnchantmentType.Blood;

        }
        else if (enchantmentList.Contains("HolyWater"))
        {
            currentEnchantment = EnchantmentType.HolyWater;

        }
        else if (enchantmentList.Contains("Onion"))
        {
            currentEnchantment = EnchantmentType.Garlic;

        }
        else
        {
            currentEnchantment = EnchantmentType.noEffect;

        }


    }
    void enemyLogic()
    {
        int randomNum = Random.Range(0, 3);

        if (enemyUnit.currentHP < enemyUnit.maxHP / 2 && randomNum == 1 && playerUnit.currentHP >= enemyUnit.damage.y * 1.5f)
        {
            int heal = (int)Random.Range((enemyUnit.damage.x + 1) * 2, enemyUnit.damage.y * 2);
            dialogueTxt.text = enemyUnit.unitName + " healed: " + heal + " HP";
            enemyUnit.currentHP += heal;
            enemyUnit.animator.SetBool("Healing", true);

        }
        else if (enemyUnit.currentHP < enemyUnit.maxHP / 1.5f && randomNum >= 1)
        {
            int lifesteal = (int)Random.Range(enemyUnit.damage.x, enemyUnit.damage.y * 0.70f);
            playerIsDead = playerUnit.takeDamage(lifesteal);

            dialogueTxt.text = enemyUnit.unitName + " lifesteal: " + lifesteal + " HP";
            enemyUnit.currentHP += lifesteal;
            enemyUnit.animator.SetBool("Attacking", true);

        }
        else
        {
            int damage = (int)Random.Range(enemyUnit.damage.x, enemyUnit.damage.y);
            playerIsDead = playerUnit.takeDamage(damage);
            dialogueTxt.text = "You got hit: " + damage + " DMG";
            enemyUnit.animator.SetBool("Attacking", true);

        }

        if (enemyUnit.currentHP > enemyUnit.maxHP)
        {
            enemyUnit.currentHP = enemyUnit.maxHP;
        }
        if(playerUnit.currentHP <= 0)
        {
            playerUnit.currentHP = 0;
        }
    }

    void enemyLevelBased(int level)
    {
        enemyUnit.maxHP += enemyUnit.maxHP * level/10;
        enemyUnit.currentHP += enemyUnit.currentHP * level / 10;
        enemyUnit.damage.x += enemyUnit.damage.x * level / 10;
        enemyUnit.damage.y += enemyUnit.damage.y * level / 10;
        enemyUnit.Gold += enemyUnit.Gold * level / 10;
        enemyUnit.xpToGive += enemyUnit.xpToGive * level / 10;

    }
}