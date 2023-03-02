using System;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Main Function: 
 * To handle the functions/actions/events sent by interfaces created from GameInput Action Map
 * as GameInput is inheriting from Game.Input.Interface(s) play mode and pause mode as of now.
 * it can read the actions called with the context parameter holding the data for the input actions
 * actions are subscribed inside TankMovementService
 * 
 * Action?.Invoke() is null operational check similar to 
 * if(Action != null)
 *     Action.Invoke();
 */

[CreateAssetMenu(menuName = "ScriptableObjects/InputReader", fileName ="InputReader")]
public class InputReader : ScriptableObject, TankBattle.InputSystem.GameInputMap.IGameplayActions, TankBattle.InputSystem.GameInputMap.IUIActions
{
    private TankBattle.InputSystem.GameInputMap gameInput;

    private void OnEnable()
    {
        if(gameInput == null)
        {
            gameInput = new TankBattle.InputSystem.GameInputMap();
            gameInput.Gameplay.SetCallbacks(this);
            gameInput.UI.SetCallbacks(this);
        }

        SetGameplay();
    }

    public void SetGameplay()
    {
        gameInput.Gameplay.Enable();
        gameInput.UI.Disable();
    }
    public void SetUI()
    {
        gameInput.Gameplay.Disable();
        gameInput.UI.Enable();
    }

    // event creator publisher
    public event Action<Vector2> MoveEvent;

    public event Action JumpEvent;
    public event Action JumpCancelledEvent;

    public event Action PauseEvent;
    public event Action ResumeEvent;

    public void OnMove(InputAction.CallbackContext context)
    {
        // Sending direct vector2 value for movement displacement vector
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            JumpEvent?.Invoke();
        }
        if(context.phase == InputActionPhase.Canceled)
        {
            JumpCancelledEvent?.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            PauseEvent?.Invoke();
            SetUI();
        }
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            ResumeEvent?.Invoke();
            SetGameplay();
        }
    }
}
