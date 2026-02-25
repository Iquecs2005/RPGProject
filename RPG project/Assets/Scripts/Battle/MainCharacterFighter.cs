using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterFighter : AllyFighter
{
    public override void OnDeath()
    {
        BattleController.instance.OnMCDeath();

        Destroy(gameObject);
    }
}
