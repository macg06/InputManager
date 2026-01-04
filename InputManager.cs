using UnityEngine;
using UnityEngine.InputSystem;

namespace MACG.InputManager
{
    public static class InputManager
    {
        /// <summary>
        /// MACG: Can be used for disabling input temporarily, like in a pause menu, loading screen transitions...
        /// It's great for avoiding bugs when maybe you don't want to read input!
        /// You can simply do: InputManager.ReadInput = false;
        /// And once your transition/whatever is done, you can do: InputManager.ReadInput = true;
        /// To set it back. Cool stuff!
        /// </summary>
        public static bool ReadInput = true;

        #region GetKey
        public static bool GetKeyDown(Key keyCode)
        {
            if (!ReadInput || Keyboard.current == null) return false;
            return Keyboard.current[keyCode].wasPressedThisFrame;
        }

        public static bool GetKeyUp(Key keyCode)
        {
            if (!ReadInput || Keyboard.current == null) return false;
            return Keyboard.current[keyCode].wasReleasedThisFrame;
        }

        public static bool GetKey(Key keyCode)
        {
            if (!ReadInput || Keyboard.current == null) return false;
            return Keyboard.current[keyCode].isPressed;
        }
        #endregion

        #region AnyKey
        public static bool anyKey()
        {
            if (!ReadInput || Keyboard.current == null) return false;
            return Keyboard.current.anyKey.isPressed;
        }

        public static bool anyKeyDown()
        {
            if (!ReadInput || Keyboard.current == null) return false;
            return Keyboard.current.anyKey.wasPressedThisFrame;
        }

        public static bool anyKeyUp()
        {
            if (!ReadInput || Keyboard.current == null) return false;
            return Keyboard.current.anyKey.wasReleasedThisFrame;
        }
        #endregion

        #region Mouse
        public static bool GetMouseButton(int value)
        {
            if (!ReadInput || Mouse.current == null) return false;
            switch (value)
            {
                case 0:
                    return Mouse.current.leftButton.isPressed;
                case 1:
                    return Mouse.current.rightButton.isPressed;
                case 2:
                    return Mouse.current.middleButton.isPressed;
                default:
                    return false;
            }
        }

        public static bool GetMouseButtonDown(int value)
        {
            if (!ReadInput || Mouse.current == null) return false;
            switch (value)
            {
                case 0:
                    return Mouse.current.leftButton.wasPressedThisFrame;
                case 1:
                    return Mouse.current.rightButton.wasPressedThisFrame;
                case 2:
                    return Mouse.current.middleButton.wasPressedThisFrame;
                default:
                    return false;
            }
        }

        public static bool GetMouseButtonUp(int value)
        {
            if (!ReadInput || Mouse.current == null) return false;
            switch (value)
            {
                case 0:
                    return Mouse.current.leftButton.wasReleasedThisFrame;
                case 1:
                    return Mouse.current.rightButton.wasReleasedThisFrame;
                case 2:
                    return Mouse.current.middleButton.wasReleasedThisFrame;
                default:
                    return false;
            }
        }
        #endregion

        #region Axis
        public static float GetAxis(string axisName)
        {
            if (!ReadInput) return 0;
            switch (axisName)
            {
                case "Horizontal":
                    float gamepadX = 0f;
                    if (Gamepad.current != null)
                        gamepadX = Gamepad.current.leftStick.x.ReadValue() + Gamepad.current.dpad.x.ReadValue();

                    float keyboardX = 0f;
                    if (Keyboard.current != null)
                    {
                        keyboardX += Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed ? -1f : 0f;
                        keyboardX += Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed ? 1f : 0f;
                    }

                    return Mathf.Clamp(gamepadX + keyboardX, -1f, 1f);

                case "Vertical":
                    float gamepadY = 0f;
                    if (Gamepad.current != null)
                        gamepadY = Gamepad.current.leftStick.y.ReadValue() + Gamepad.current.dpad.y.ReadValue();

                    float keyboardY = 0f;
                    if (Keyboard.current != null)
                    {
                        keyboardY += Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed ? 1f : 0f;
                        keyboardY += Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed ? -1f : 0f;
                    }

                    return Mathf.Clamp(gamepadY + keyboardY, -1f, 1f);

                case "Mouse X":
                    if (Mouse.current != null)
                        return Mouse.current.delta.x.ReadValue();
                    return 0f;

                case "Mouse Y":
                    if (Mouse.current != null)
                        return Mouse.current.delta.y.ReadValue();
                    return 0f;

                case "Jump":
                    if (Keyboard.current != null && Keyboard.current.spaceKey.isPressed) return 1f;
                    if (Gamepad.current != null && Gamepad.current.buttonSouth.isPressed) return 1f;
                    return 0f;

                default:
                    throw new System.NotImplementedException($"No mapping for axis {axisName}");
            }
        }
        #endregion
    }
}