using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VitalsDisplayController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider hpSlider;
    [SerializeField] private TMP_Text hpValueText;
    [SerializeField] private Slider spSlider;
    [SerializeField] private TMP_Text spValueText;
    [SerializeField] private Image iconImage;

    private PartyMemberData memberData;

    public void Initialize(PartyMemberData data) 
    {
        memberData = data;

        data.OnHealthAlteredEvent.AddListener(UpdateUI);
        UpdateUI(memberData);
    }

    public void UpdateUI(PartyMemberData data) 
    {
        iconImage.sprite = memberData.battleIcon;
        SetSlider(hpSlider, memberData.currentHealth, memberData.maxHealth);
        SetValueText(hpValueText, memberData.currentHealth);
        SetSlider(spSlider, memberData.currentSP, memberData.maxSP);
        SetValueText(spValueText, memberData.currentSP);
    }

    private void SetSlider(Slider slider, int newValue, int maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = newValue;
    }

    private void SetValueText(TMP_Text textObject, int newValue) 
    {
        string valueString = newValue.ToString();

        for (int i = valueString.Length; i < 3; i++)
        {
            valueString = 0 + valueString;
        }

        textObject.text = valueString;
    }
}
