using UnityEngine;
using UnityEngine.UI;

namespace InputSystem
{
    [System.Serializable]
    public class InputSystem
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JoyButton _fireButton;
        
        public Joystick Joystick => _joystick;
        public JoyButton FireButton => _fireButton;
        
    }
}