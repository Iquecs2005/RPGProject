using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyFighter : BattleFighter
{
    [SerializeField] private PartyMemberData data;

    private void OnEnable()
    {
        data.OnDeathEvent.AddListener(OnDeathWrapper);
    }

    private void OnDisable()
    {
        
    }

    public override void OnTurnStart()
    {
        BattleActionsUI.instance.ActivateUI(this);
    }

    public override void OnTurnEnd()
    {
        BattleActionsUI.instance.DeactivateUI();

        base.OnTurnEnd();
    }

    public override void ReceiveDamage(int damage)
    {
        data.TakeDamage(damage);
    }

    public override void MeleeAttack(BattleFighter target) 
    {
        target.ReceiveDamage(data.meleeDamage);
        OnTurnEnd();
    }

    private void OnDeathWrapper(PartyMemberData data) 
    {
        OnDeath();
    }
}
