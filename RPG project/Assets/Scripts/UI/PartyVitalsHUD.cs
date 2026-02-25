using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyVitalsHUD : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject canvasObject;
    [SerializeField] private GameObject displayHolder;

    [Header("Variables")]
    [SerializeField] private GameObject vitalsDisplayPrefab;

    void Start()
    {
        List<PartyMemberData> data = PartyManager.GetPartyMembersData();

        foreach (PartyMemberData memberData in data)
        {
            GameObject vitalsDisplay = Instantiate(vitalsDisplayPrefab, displayHolder.transform);
            VitalsDisplayController vitalsDisplayController = vitalsDisplay.GetComponent<VitalsDisplayController>();
            vitalsDisplayController.Initialize(memberData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
