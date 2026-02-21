using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; }

    [Header("References")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private FreeroamInput freeroam;
    [SerializeField] private MenusInput menus;

    public static UnityEvent OnPauseAction { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(instance);
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);

        OnPauseAction = new UnityEvent();
    }

    public static void ChangeActionMap(ActionMap actionMap) 
    {
        string actionMapName = "";
        
        switch (actionMap) 
        {
            case ActionMap.Freeroam:
                actionMapName = "Freeroam";
                break;
            case ActionMap.Menus:
                actionMapName = "Menus";
                break;
        }

        instance.playerInput.SwitchCurrentActionMap(actionMapName);
    }
}

public enum ActionMap
{
    Freeroam, Menus
}
