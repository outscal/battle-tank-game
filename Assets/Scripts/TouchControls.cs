// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/TouchControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""b6ea59ee-0217-4760-8cd1-a16fac0a2291"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""38d6fc16-1e01-4cbd-bf86-0f5c72f18f73"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""1d085ef1-c213-4441-b9ce-2a8d16d49a30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""588f0106-48f5-465c-92eb-2b8f946bd0d9"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5fc3246-9d29-4941-8a4c-0171b97ed6e2"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""test_jump"",
            ""id"": ""5bcc8339-0fa8-4119-9472-fcf857425f9d"",
            ""actions"": [
                {
                    ""name"": ""jump1"",
                    ""type"": ""Button"",
                    ""id"": ""488d7399-5c89-459e-b0be-c9aa7b5535b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""96942469-2a97-4762-8a4b-6bb34ea77d19"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_Move = m_Touch.FindAction("Move", throwIfNotFound: true);
        m_Touch_Press = m_Touch.FindAction("Press", throwIfNotFound: true);
        // test_jump
        m_test_jump = asset.FindActionMap("test_jump", throwIfNotFound: true);
        m_test_jump_jump1 = m_test_jump.FindAction("jump1", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_Move;
    private readonly InputAction m_Touch_Press;
    public struct TouchActions
    {
        private @TouchControls m_Wrapper;
        public TouchActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Touch_Move;
        public InputAction @Press => m_Wrapper.m_Touch_Press;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnMove;
                @Press.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPress;
                @Press.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPress;
                @Press.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPress;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Press.started += instance.OnPress;
                @Press.performed += instance.OnPress;
                @Press.canceled += instance.OnPress;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);

    // test_jump
    private readonly InputActionMap m_test_jump;
    private ITest_jumpActions m_Test_jumpActionsCallbackInterface;
    private readonly InputAction m_test_jump_jump1;
    public struct Test_jumpActions
    {
        private @TouchControls m_Wrapper;
        public Test_jumpActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @jump1 => m_Wrapper.m_test_jump_jump1;
        public InputActionMap Get() { return m_Wrapper.m_test_jump; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Test_jumpActions set) { return set.Get(); }
        public void SetCallbacks(ITest_jumpActions instance)
        {
            if (m_Wrapper.m_Test_jumpActionsCallbackInterface != null)
            {
                @jump1.started -= m_Wrapper.m_Test_jumpActionsCallbackInterface.OnJump1;
                @jump1.performed -= m_Wrapper.m_Test_jumpActionsCallbackInterface.OnJump1;
                @jump1.canceled -= m_Wrapper.m_Test_jumpActionsCallbackInterface.OnJump1;
            }
            m_Wrapper.m_Test_jumpActionsCallbackInterface = instance;
            if (instance != null)
            {
                @jump1.started += instance.OnJump1;
                @jump1.performed += instance.OnJump1;
                @jump1.canceled += instance.OnJump1;
            }
        }
    }
    public Test_jumpActions @test_jump => new Test_jumpActions(this);
    public interface ITouchActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPress(InputAction.CallbackContext context);
    }
    public interface ITest_jumpActions
    {
        void OnJump1(InputAction.CallbackContext context);
    }
}
