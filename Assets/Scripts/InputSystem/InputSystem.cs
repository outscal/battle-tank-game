using UnityEngine;

namespace InputSystem
{
    [System.Serializable]
    public class InputSystem
    {
        #region Serialized Data members

        [SerializeField] private Joystick joystick;
        [SerializeField] private JoyButton fireButton;

        #endregion

        #region Getters

        public Joystick Joystick => joystick;
        public JoyButton FireButton => fireButton;

        #endregion
    }
}