using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance { get; private set; }

    private BattleState currentState;

    [SerializeField] private GameObject[] enemiesPrefab;

    [SerializeField] private Transform[] alliesPositions;
    [SerializeField] private Transform[] enemiesPositions;

    private List<BattleFighter> allyBattleFighters = new List<BattleFighter>();
    private List<BattleFighter> enemyBattleFighters = new List<BattleFighter>();
    private List<BattleFighter> turnOrder = new List<BattleFighter>();

    private BattleFighter currentTurnBF;

    private enum BattleState 
    {
        PlayerTurn, EnemyTurn, Win, Lost
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }

        instance = this;
        //DontDestroyOnLoad(instance);
    }

    private void Start()
    {
        InstantiateFighters();
        StartNextTurn();
    }

    private void InstantiateFighters() 
    {
        List<PartyMemberData> partyMembers = PartyManager.GetPartyMembersData();

        for (int i = 0; i < partyMembers.Count; i++)
        {
            GameObject allyPrefab = partyMembers[i].battlePrefab;
            GameObject newAlly = Instantiate(allyPrefab, alliesPositions[i].position, alliesPositions[i].rotation);
            allyBattleFighters.Add(newAlly.GetComponent<BattleFighter>());
        }

        for (int i = 0; i < enemiesPrefab.Length; i++)
        {
            GameObject enemyPrefab = enemiesPrefab[i];
            GameObject newEnemy = Instantiate(enemyPrefab, enemiesPositions[i].position, enemiesPositions[i].rotation);
            enemyBattleFighters.Add(newEnemy.GetComponent<BattleFighter>());
        }
    }

    private void StartNextTurn() 
    {
        if (currentState == BattleState.Win || currentState == BattleState.Lost)
        {
            return;
        }

        if (turnOrder.Count == 0) 
        {
            turnOrder.AddRange(allyBattleFighters);
            turnOrder.AddRange(enemyBattleFighters);
        }

        BattleFighter turnFighter = turnOrder[0];
        turnOrder.RemoveAt(0);

        StartUnitTurn(turnFighter);
    }

    private void StartUnitTurn(BattleFighter battleFighter) 
    {
        currentTurnBF = battleFighter;
        currentTurnBF.OnTurnStart();
    }

    public void EndUnitTurn(BattleFighter battleFighter) 
    {
        if (currentTurnBF != battleFighter)
            return;

        StartNextTurn();
    }

    //public void Attack(bool player, bool targetPlayer, int damage) 
    //{
    //    //switch (currentState) 
    //    //{
    //    //    case BattleState.PlayerTurn:
    //    //        if (!player)
    //    //            return;
    //    //        break;
    //    //    case BattleState.EnemyTurn:
    //    //        if (player)
    //    //            return;
    //    //        break;
    //    //    default:
    //    //        return;
    //    //}

    //    //if (targetPlayer)
    //    //{
    //    //    playerHealth -= damage;
    //    //    if (playerHealth <= 0)
    //    //    {
    //    //        Destroy(allyGO);
    //    //        EndBattle();
    //    //        return;
    //    //    }
    //    //    EndEnemyTurn();
    //    //}
    //    //else
    //    //{
    //    //    enemyHealth -= damage;
    //    //    if (enemyHealth <= 0)
    //    //    {
    //    //        Destroy(enemyGO);
    //    //        EndBattle();
    //    //        return;
    //    //    }
    //    //    EndPlayerTurn();
    //    //}
    //} 

    public void OnUnitDeath(BattleFighter battleFighter) 
    {
        turnOrder.Remove(battleFighter);

        if (allyBattleFighters.Remove(battleFighter)) 
        {
            if (allyBattleFighters.Count == 0)
            {
                print("Battle Lost");
                currentState = BattleState.Lost;
            }
        }
        else if (enemyBattleFighters.Remove(battleFighter))
        {
            if (enemyBattleFighters.Count == 0) 
            {
                print("Battle Won");
                currentState = BattleState.Win;
            }
        }
    }

    public void OnMCDeath() 
    {
        print("Battle Lost");
        currentState = BattleState.Lost;
    }

    //public void EndBattle()
    //{
    //    if (playerHealth <= 0)
    //    {
    //        print("Battle Lost");
    //        currentState = BattleState.Lost;
    //    }
    //    else if (enemyHealth <= 0)
    //    {
    //        print("Battle Won");
    //        currentState = BattleState.Win;
    //    }
    //}

    public List<BattleFighter> GetPlayer() 
    {
        return allyBattleFighters;
    }

    public List<BattleFighter> GetEnemy()
    {
        return enemyBattleFighters;
    }
}
