using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlightHandler : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject)
            return;

        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
