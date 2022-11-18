using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class Combat : MonoBehaviour
{
    public PlayerEntity playerStats;

    public WorldManager WorldManager;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerStation;
    public Transform enemyStation;

    PlayerUnit playerUnit;
    Unit enemyUnit;

    public CombatHud playerHud;
    public CombatHud enemyHud;

    public BattleState state;

    [SerializeField] TextMeshProUGUI dialogueTxt;

    [SerializeField] Button attackBtn;

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
        enemyUnit.setStats();

        dialogueTxt.text = "You are fighting " + enemyUnit.unitName;

        playerHud.setHudPlayer(playerUnit);
        enemyHud.setHudUnit(enemyUnit);

        yield return new WaitForSeconds(2);

        state = BattleState.PLAYERTURN;
        playerTurn();
    }

    IEnumerator playerAttack()
    {
        playerUnit.attack(true);
        int damage = (int)Random.Range(playerUnit.damage.x, playerUnit.damage.y + 1);
        bool isDead = enemyUnit.takeDamage(damage);
        enemyHud.setHudUnit(enemyUnit);
        dialogueTxt.text = "Hit: " + damage + " DMG";
        ShakeScreen.isShaking = true;
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

        int damage = (int)Random.Range(enemyUnit.damage.x, enemyUnit.damage.y + 1);
        bool isDead = playerUnit.takeDamage(damage);
        playerHud.setHudPlayer(playerUnit);
        ShakeScreen.isShaking = true;
        dialogueTxt.text = "You got hit: " + damage + " DMG";


        yield return new WaitForSeconds(1);

        if (isDead)
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

       // SceneManager.LoadScene(1);
      //  WorldManager.gameDone();
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

   
}
