using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyFighter : BattleFighter
{
    private void Start()
    {
        currentHealth = maxHealth;
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
}
