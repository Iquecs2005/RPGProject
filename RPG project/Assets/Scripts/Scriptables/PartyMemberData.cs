using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/New Party Member Data")]
public class PartyMemberData : ScriptableObject
{
    [Header("References")]
    public GameObject battlePrefab;

    [Header("Stats")]
    public int maxHealth;
    public int currentHealth;
    public int maxSP;
    public int currentSP;
    public int meleeDamage;

    [Header("Assets")]
    public Sprite battleIcon;

    [Header("Events")]
    //Por enquanto esse parametro é inutil, mas pode ser util quando algo deve acontecer quando qualquer
    //personagem morrer e precisar identificar qual morreu 
    public UnityEvent<PartyMemberData> OnHealthAlteredEvent;
    public UnityEvent<PartyMemberData> OnDeathEvent;

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeathEvent.Invoke(this);
        }

        OnHealthAlteredEvent.Invoke(this);
    }
}
