using MACG.InputManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExampleUsage : MonoBehaviour
{
    private void Update()
    {
        if (InputManager.GetKeyDown(Key.V)) Debug.Log("Pressed down V!");
        else if (InputManager.GetKeyUp(Key.V)) Debug.Log("Released V!");

        if (InputManager.GetMouseButton(0)) Debug.Log("Pressing the right click...");

        if (InputManager.GetMouseButtonDown(0)) Debug.Log("Used right click button!");
        else if (Input.GetMouseButtonUp(0)) Debug.Log("Released the right click!");
    }
}
