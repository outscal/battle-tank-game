using GlobalServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIServices
{
    // Calls event based on current state of button.
    public class LongButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        // Calls when button is pressed.
        public void OnPointerDown(PointerEventData eventData)
        {
            EventService.Instance.InvokeOnFireButtonPressedEvent();
        }

        // Calls when button is released.
        public void OnPointerUp(PointerEventData eventData)
        {
            EventService.Instance.InvokeOnFireButtonReleasedEvent();
        }
    }
}
