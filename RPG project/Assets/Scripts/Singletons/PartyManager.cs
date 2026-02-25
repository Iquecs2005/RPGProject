using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public static PartyManager instance { get; private set; }

    [SerializeField] private List<PartyMemberData> currentPartyMembers;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static List<PartyMemberData> GetPartyMembersData() 
    {
        List<PartyMemberData> copy = new List<PartyMemberData>(instance.currentPartyMembers);

        return copy;
    }
}
