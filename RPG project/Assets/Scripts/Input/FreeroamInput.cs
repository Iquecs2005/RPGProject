using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FreeroamInput : MonoBehaviour
{
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
            print("Interacted");
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            InputManager.OnPauseAction.Invoke();
            print("Paused");
            InputManager.ChangeActionMap(ActionMap.Menus);
        }
    }
}
