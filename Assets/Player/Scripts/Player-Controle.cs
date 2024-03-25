//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Player/Scripts/Player-Controle.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControle: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControle()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player-Controle"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""59b7fd9f-b48b-40c1-be03-fc9d04c150f3"",
            ""actions"": [
                {
                    ""name"": ""WASD"",
                    ""type"": ""Value"",
                    ""id"": ""b6f50f10-da81-4755-81ac-67321c246bba"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SETAS"",
                    ""type"": ""Value"",
                    ""id"": ""49632f99-9775-4eea-a466-391c18380ef8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""type"": ""Value"",
                    ""id"": ""a4ab45d7-99be-4fb7-8a20-a1da756b5358"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""53f5b3cc-ca22-4650-8cb8-88201f208615"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ataque"",
                    ""type"": ""Button"",
                    ""id"": ""e868026b-a1de-4ae5-a8c3-49c60c8578db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""type"": ""Value"",
                    ""id"": ""dd43067d-1c66-464f-9e9d-9f79985ffebc"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AbreBau"",
                    ""type"": ""Value"",
                    ""id"": ""fe8d77df-70d2-4f97-a45c-3efd865c6e68"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Teclado"",
                    ""id"": ""fbc46146-f909-45e8-b2c9-697712f3d3bb"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""95b55ba3-2fc2-4885-854d-abc1d4694605"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""398b9234-7d51-45b2-a811-545d13455db0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dbfca2dd-c357-4d4d-8cde-0c454ee92a57"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""93385f0d-696e-4a4d-9c41-41eb25512a05"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Teclado"",
                    ""id"": ""62c7ef4d-0b75-4a16-8852-74ad9276bff7"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SETAS"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eac6dbb2-0f27-4864-9f8e-6bbd9a753486"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SETAS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c2bdb33d-2bf8-4595-afb5-f4512105a3e4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SETAS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6d7d340e-e501-42d6-a5e9-26a2e5b78e47"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SETAS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox"",
                    ""id"": ""64ac3c85-9cc2-4dcf-aa82-2fe566a492f0"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""44bf8020-3b33-4d99-9c21-db536ddfc3c3"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ae964401-bd21-4b69-91d2-d88f03816ad5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2c1684f8-1d82-4d00-99c0-6891408220f2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8425fbc7-3c4c-419e-a080-08d3e91f48e7"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""acfd6691-c372-40dc-b965-19e6b660573d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""167725d5-b269-48b9-b731-5987d70f6be7"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ae19d2c-71ba-4bd6-aacc-8f19a4129805"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ataque"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb0f6cfb-bbff-4e4d-bc6d-f8bfb23a4ca4"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ataque"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e80584be-f480-4119-8b58-da47b4a09b6b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ataque"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""797a8b30-cc9f-4d45-b75f-2cbbe50046cb"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0d0c7008-5b19-4f70-8ef4-ad8a71188776"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""99813264-09de-4db5-bb1b-321b5e5d9bbf"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Teclado"",
                    ""id"": ""d9c47ce6-6e64-4335-887b-258cd3eb5e8d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbreBau"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""12f84e44-939f-492f-8494-816239785291"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbreBau"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_WASD = m_Move.FindAction("WASD", throwIfNotFound: true);
        m_Move_SETAS = m_Move.FindAction("SETAS", throwIfNotFound: true);
        m_Move_Joystick = m_Move.FindAction("Joystick", throwIfNotFound: true);
        m_Move_Jump = m_Move.FindAction("Jump", throwIfNotFound: true);
        m_Move_Ataque = m_Move.FindAction("Ataque", throwIfNotFound: true);
        m_Move_Gamepad = m_Move.FindAction("Gamepad", throwIfNotFound: true);
        m_Move_AbreBau = m_Move.FindAction("AbreBau", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Move
    private readonly InputActionMap m_Move;
    private List<IMoveActions> m_MoveActionsCallbackInterfaces = new List<IMoveActions>();
    private readonly InputAction m_Move_WASD;
    private readonly InputAction m_Move_SETAS;
    private readonly InputAction m_Move_Joystick;
    private readonly InputAction m_Move_Jump;
    private readonly InputAction m_Move_Ataque;
    private readonly InputAction m_Move_Gamepad;
    private readonly InputAction m_Move_AbreBau;
    public struct MoveActions
    {
        private @PlayerControle m_Wrapper;
        public MoveActions(@PlayerControle wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_Move_WASD;
        public InputAction @SETAS => m_Wrapper.m_Move_SETAS;
        public InputAction @Joystick => m_Wrapper.m_Move_Joystick;
        public InputAction @Jump => m_Wrapper.m_Move_Jump;
        public InputAction @Ataque => m_Wrapper.m_Move_Ataque;
        public InputAction @Gamepad => m_Wrapper.m_Move_Gamepad;
        public InputAction @AbreBau => m_Wrapper.m_Move_AbreBau;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void AddCallbacks(IMoveActions instance)
        {
            if (instance == null || m_Wrapper.m_MoveActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MoveActionsCallbackInterfaces.Add(instance);
            @WASD.started += instance.OnWASD;
            @WASD.performed += instance.OnWASD;
            @WASD.canceled += instance.OnWASD;
            @SETAS.started += instance.OnSETAS;
            @SETAS.performed += instance.OnSETAS;
            @SETAS.canceled += instance.OnSETAS;
            @Joystick.started += instance.OnJoystick;
            @Joystick.performed += instance.OnJoystick;
            @Joystick.canceled += instance.OnJoystick;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Ataque.started += instance.OnAtaque;
            @Ataque.performed += instance.OnAtaque;
            @Ataque.canceled += instance.OnAtaque;
            @Gamepad.started += instance.OnGamepad;
            @Gamepad.performed += instance.OnGamepad;
            @Gamepad.canceled += instance.OnGamepad;
            @AbreBau.started += instance.OnAbreBau;
            @AbreBau.performed += instance.OnAbreBau;
            @AbreBau.canceled += instance.OnAbreBau;
        }

        private void UnregisterCallbacks(IMoveActions instance)
        {
            @WASD.started -= instance.OnWASD;
            @WASD.performed -= instance.OnWASD;
            @WASD.canceled -= instance.OnWASD;
            @SETAS.started -= instance.OnSETAS;
            @SETAS.performed -= instance.OnSETAS;
            @SETAS.canceled -= instance.OnSETAS;
            @Joystick.started -= instance.OnJoystick;
            @Joystick.performed -= instance.OnJoystick;
            @Joystick.canceled -= instance.OnJoystick;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Ataque.started -= instance.OnAtaque;
            @Ataque.performed -= instance.OnAtaque;
            @Ataque.canceled -= instance.OnAtaque;
            @Gamepad.started -= instance.OnGamepad;
            @Gamepad.performed -= instance.OnGamepad;
            @Gamepad.canceled -= instance.OnGamepad;
            @AbreBau.started -= instance.OnAbreBau;
            @AbreBau.performed -= instance.OnAbreBau;
            @AbreBau.canceled -= instance.OnAbreBau;
        }

        public void RemoveCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMoveActions instance)
        {
            foreach (var item in m_Wrapper.m_MoveActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MoveActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MoveActions @Move => new MoveActions(this);
    public interface IMoveActions
    {
        void OnWASD(InputAction.CallbackContext context);
        void OnSETAS(InputAction.CallbackContext context);
        void OnJoystick(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAtaque(InputAction.CallbackContext context);
        void OnGamepad(InputAction.CallbackContext context);
        void OnAbreBau(InputAction.CallbackContext context);
    }
}
