using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : BattleFighter
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    [SerializeField] private int meleeDamage;

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
        BattleFighter playerBF = BattleController.instance.GetPlayer()[0];
        MeleeAttack(playerBF);
    }

    public override void ReceiveDamage(int damage) 
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }

    public override void MeleeAttack(BattleFighter target) 
    {
        target.ReceiveDamage(meleeDamage);
        OnTurnEnd();
    }
}
