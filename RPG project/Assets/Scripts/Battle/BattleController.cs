using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance { get; private set; }

    private BattleState currentState;

    [SerializeField] private int maxPlayerHealth;
    private int playerHealth;
    [SerializeField] private int maxEnemyHealth;
    private int enemyHealth;

    [SerializeField] private GameObject allyPrefab;
    [SerializeField] private GameObject enemyPrefab;
    GameObject allyGO;
    GameObject enemyGO;

    [SerializeField] private Transform[] alliesPositions;
    [SerializeField] private Transform[] enemiesPositions;

    private BattleFighter allyBattleFighters;
    private BattleFighter enemyBattleFighters;

    private enum BattleState 
    {
        PlayerTurn, EnemyTurn, Win, Lost
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);
    }

    private void Start()
    {
        allyGO = Instantiate(allyPrefab, alliesPositions[0].position, alliesPositions[0].rotation);
        enemyGO = Instantiate(enemyPrefab, enemiesPositions[0].position, enemiesPositions[0].rotation);

        allyBattleFighters = allyGO.GetComponent<BattleFighter>();
        enemyBattleFighters = enemyGO.GetComponent<BattleFighter>();

        playerHealth = maxPlayerHealth;
        enemyHealth = maxEnemyHealth;

        StartPlayerTurn();
    }

    private void StartPlayerTurn() 
    {
        currentState = BattleState.PlayerTurn;
    }

    private void EndPlayerTurn()
    {
        StartEnemyTurn();
    }

    private void StartEnemyTurn()
    {
        currentState = BattleState.EnemyTurn;
        Attack(false, true, 10);
    }

    private void EndEnemyTurn()
    {
        StartPlayerTurn();
    }

    public void Attack(bool player, bool targetPlayer, int damage) 
    {
        switch (currentState) 
        {
            case BattleState.PlayerTurn:
                if (!player)
                    return;
                break;
            case BattleState.EnemyTurn:
                if (player)
                    return;
                break;
            default:
                return;
        }

        if (targetPlayer)
        {
            playerHealth -= damage;
            if (playerHealth <= 0)
            {
                Destroy(allyGO);
                EndBattle();
                return;
            }
            EndEnemyTurn();
        }
        else
        {
            enemyHealth -= damage;
            if (enemyHealth <= 0)
            {
                Destroy(enemyGO);
                EndBattle();
                return;
            }
            EndPlayerTurn();
        }
    } 

    public void EndBattle() 
    {
        if (playerHealth <= 0)
        {
            print("Battle Lost");
            currentState = BattleState.Lost;
        }
        else if (enemyHealth <= 0)
        {
            print("Battle Won");
            currentState = BattleState.Win;
        }
    }
}
