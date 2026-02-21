using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject firstSelectedObject;

    private void OnEnable()
    {
        InputManager.OnPauseAction.AddListener(ToggleActive);
    }

    private void OnDisable()
    {
        InputManager.OnPauseAction.RemoveListener(ToggleActive);
    }

    private void ToggleActive()
    {
        SetActive(!canvas.activeSelf);
    }

    private void SetActive(bool state) 
    {
        if (state == canvas.activeSelf)
            return;

        canvas.SetActive(state);

        if (state)
        {
            EventSystem.current.SetSelectedGameObject(firstSelectedObject);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void ButtonClick(string text) 
    {
        print(text);
    }
}
