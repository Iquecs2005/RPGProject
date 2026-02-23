using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFighter : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int currentHealth;

    [SerializeField] protected int meleeAttackDamage; 

    public virtual void OnTurnStart() 
    {
        OnTurnEnd();
    }

    public virtual void OnTurnEnd()
    {
        BattleController.instance.EndUnitTurn(this);
    }

    public virtual void OnDeath() 
    {
        BattleController.instance.OnUnitDeath(this);

        Destroy(gameObject);
    }

    public virtual void ReceiveDamage(int damage) 
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }

    public virtual void MeleeAttack(BattleFighter target) 
    {
        target.ReceiveDamage(meleeAttackDamage);
        OnTurnEnd();
    }
}
