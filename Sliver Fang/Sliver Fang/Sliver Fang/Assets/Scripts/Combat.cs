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

    [SerializeField] GameObject GameOverScreen;
    [SerializeField] TextMeshProUGUI GoldText, XPText, LossOrWinText;
    [SerializeField] Button bakcToGame;

    [SerializeField] GameObject damagePrefab;
    [SerializeField] GameObject deathParticlePrefab;


    Animator screenFade;

    // Start is called before the first frame update
    void Start()
    {
        screenFade = GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>();
        attackBtn.onClick.AddListener(() => onAttackButton());
        bakcToGame.onClick.AddListener(() => StartCoroutine( returnToGame()));
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
        enemyLevel = (int)Random.Range(enemyUnit.stats.level.x, enemyUnit.stats.level.y + 1);
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
        int damage = Random.Range(Mathf.RoundToInt(playerUnit.damage.x * (playerStats.upgradeDMG +1)), Mathf.RoundToInt(playerUnit.damage.y * (playerStats.upgradeDMG + 1))+1);
        bool isDead = enemyUnit.takeDamage(damage,currentEnchantment);

        GameObject dmgText = Instantiate(damagePrefab, enemyUnit.transform.position, Quaternion.identity);
        dmgText.GetComponent<TextMeshPro>().text = enemyUnit.hitInfo.ToString();
        enemyUnit.animator.SetBool("Damaged", true);

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

        if (isDead)
        {
            Instantiate(deathParticlePrefab, new Vector2(enemyUnit.transform.localPosition.x, 1), Quaternion.identity);
            enemyUnit.transform.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(1f);
        enemyUnit.animator.SetBool("Damaged", false);

        playerUnit.attack(false);

        if (isDead)
        {
            state = BattleState.WON;
            StartCoroutine(endBattle());
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

        if (playerIsDead)
        {
            Instantiate(deathParticlePrefab, new Vector2(playerUnit.transform.localPosition.x, 1), Quaternion.identity);
            playerUnit.transform.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(1);
        enemyUnit.animator.SetBool("Attacking", false);
        enemyUnit.animator.SetBool("Healing", false);

        if (playerIsDead)
        {
            state = BattleState.LOST;
            

           StartCoroutine(endBattle());
        }
        else
        {
            state = BattleState.PLAYERTURN;
            playerTurn();
        }
    }

     IEnumerator endBattle()
    {
        if(state == BattleState.WON)
        {
           

            LossOrWinText.text = "You won!";
            playerStats.gold += enemyUnit.Gold;
            playerStats.currentXP += enemyUnit.xpToGive;
            playerStats.kills++;
            playerStats.day++;
            GoldText.text = "Gold: " + enemyUnit.Gold.ToString();
            XPText.text = "XP: " + enemyUnit.xpToGive.ToString();

        }
        else if (state == BattleState.LOST)
        {


            LossOrWinText.text = "You lost!";
            playerStats.currentXP += Mathf.RoundToInt( enemyUnit.xpToGive / 4);
            playerStats.day++;
            GoldText.text = "Gold: " + "0";
            XPText.text = "XP: " + Mathf.RoundToInt(enemyUnit.xpToGive / 4).ToString();


        }
        dialogueTxt.text = "";

     yield  return new WaitForSeconds(1f);
     GameOverScreen.SetActive(true);
   
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
            int heal = (int)Random.Range((enemyUnit.damage.x + 1) * 2, (enemyUnit.damage.y+1) * 2);
            dialogueTxt.text = enemyUnit.unitName + " healed: " + heal + " HP";
            enemyUnit.currentHP += heal;
            enemyUnit.animator.SetBool("Healing", true);

            GameObject healText = Instantiate(damagePrefab, enemyUnit.transform.position, Quaternion.identity);
            healText.GetComponent<TextMeshPro>().text = heal.ToString();
            healText.GetComponent<TextMeshPro>().color = Color.green;
        }
        else if (enemyUnit.currentHP < enemyUnit.maxHP / 1.5f && randomNum >= 1)
        {
            int lifesteal = (int)Random.Range(enemyUnit.damage.x, (enemyUnit.damage.y +1) * 0.70f);
            playerIsDead = playerUnit.takeDamage(lifesteal);

            dialogueTxt.text = enemyUnit.unitName + " lifesteal: " + lifesteal + " HP";
            enemyUnit.currentHP += lifesteal;
            enemyUnit.animator.SetBool("Attacking", true);
            GameObject text = Instantiate(damagePrefab, playerUnit.transform.position, Quaternion.identity);
            text.GetComponent<TextMeshPro>().text = lifesteal.ToString();

            GameObject healText = Instantiate(damagePrefab, enemyUnit.transform.position, Quaternion.identity);
            healText.GetComponent<TextMeshPro>().text = lifesteal.ToString();
            healText.GetComponent<TextMeshPro>().color = Color.green;
        }
        else
        {
            int damage = (int)Random.Range(enemyUnit.damage.x, enemyUnit.damage.y + 1);
            playerIsDead = playerUnit.takeDamage(damage);
            dialogueTxt.text = "You got hit: " + damage + " DMG";
            enemyUnit.animator.SetBool("Attacking", true);
            GameObject text = Instantiate(damagePrefab, playerUnit.transform.position, Quaternion.identity);
            text.GetComponent<TextMeshPro>().text = damage.ToString();
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

    IEnumerator returnToGame()
    {
        screenFade.SetTrigger("Fade");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
        WorldManager.gameDone();
    }
}
