using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActionsUI : MonoBehaviour
{
    public static BattleActionsUI instance { get; private set; }

    [SerializeField] private GameObject actionCanvas;

    private BattleFighter currentFighter;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }

        instance = this;
        //DontDestroyOnLoad(instance);
    }

    public void ActivateUI(BattleFighter fighter) 
    {
        if (currentFighter != null)
            return;

        currentFighter = fighter;
        actionCanvas.SetActive(true);
    }

    public void DeactivateUI()
    {
        actionCanvas.SetActive(false);
        currentFighter = null;
    }

    public void OnAttackButton() 
    {
        if (currentFighter == null)
            return;

        currentFighter.MeleeAttack(BattleController.instance.GetEnemy()[0]);
    }
}
