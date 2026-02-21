using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenusInput : MonoBehaviour
{
    public void OnConfirm(InputAction.CallbackContext context)
    {
        //if (context.performed)
        //    print("Confirmed");
    }

    public void OnUnpause(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            InputManager.OnPauseAction.Invoke();
            InputManager.ChangeActionMap(ActionMap.Freeroam);
        }
    }
}
