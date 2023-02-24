using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class EnhancedTouchManager : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
    }

    private void Start()
    {
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {

    }

    private void Update()
    {
        foreach(var touch in Touch.activeTouches)
        {
            Debug.Log($"{touch.touchId}: {touch.screenPosition},{touch.phase}");
        }
    }
}
