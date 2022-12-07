using UnityEngine;

namespace DiInput
{
    public class KeyInputMoveProvider : IInputMoveProvider
    {
        public bool InputLeft()
        {
            return UnityEngine.Input.GetKey(KeyCode.A);
        }

        public bool InputRight()
        {
            return UnityEngine.Input.GetKey(KeyCode.D);
        }
    }
}