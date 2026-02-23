using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : BattleFighter
{
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public override void OnTurnStart()
    {
        StartCoroutine(think());
    }

    private IEnumerator think() 
    {
        yield return new WaitForSeconds(1);
        BattleFighter playerBF = BattleController.instance.GetPlayer();
        MeleeAttack(playerBF);
    }
}
