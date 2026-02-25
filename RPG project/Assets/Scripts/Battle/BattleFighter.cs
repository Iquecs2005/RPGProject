using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleFighter : MonoBehaviour
{
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

    public abstract void ReceiveDamage(int damage);
    public abstract void MeleeAttack(BattleFighter target);
}
