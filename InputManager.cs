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
    }
}