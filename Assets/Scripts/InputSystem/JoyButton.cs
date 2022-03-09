using UnityEngine;
using UnityEngine.EventSystems;

namespace InputSystem
{
    public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        #region Private Data members

        private bool _pressed;

        #endregion

        #region Getters

        public bool Pressed => _pressed;

        #endregion

        #region Unity Interfaces Functions

        public void OnPointerUp(PointerEventData eventData)
        {
            _pressed = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pressed = true;
        }

        #endregion
    }
}