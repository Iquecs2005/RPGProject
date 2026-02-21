using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTest : MonoBehaviour
{
    [SerializeField] private int damage;

    public void Attack() 
    {
        BattleController.instance.Attack(true, false, damage);
    }
}
