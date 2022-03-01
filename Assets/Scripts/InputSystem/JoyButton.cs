using UnityEngine;
using UnityEngine.EventSystems;

namespace InputSystem
{
    public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        private bool _pressed;
        public bool Pressed => _pressed;
        public void OnPointerUp(PointerEventData eventData)
        {
            _pressed = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pressed = true;
        }
    }
}