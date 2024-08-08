//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/11.InputSystem/Console.inputactions
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

public partial class @Console: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Console()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Console"",
    ""maps"": [
        {
            ""name"": ""Floor"",
            ""id"": ""41c97255-febe-4a74-a3b2-2f6a481b5331"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6d17ed3c-7ce1-4d60-9603-2d7ebd56acae"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""aa1c7cac-ae96-4509-a14c-4ab861cdbf10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Booster"",
                    ""type"": ""Button"",
                    ""id"": ""25db23af-aa20-407d-8ecb-edf266e78f6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ReSpawn"",
                    ""type"": ""Button"",
                    ""id"": ""56cd7ee9-98e4-4daf-8f24-de455c928bc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SubAttack"",
                    ""type"": ""Button"",
                    ""id"": ""d3313f97-09f6-4772-92a8-271a32a55f3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""010369e5-bde9-4a9a-90e3-52b2384a5d2e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""af8b8e25-3e98-4c00-b969-515da0d12add"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c0d1bf4a-7b10-4410-98a8-8a21b636d232"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""64e56a59-eb7b-4fe6-809d-17d7cb854fc7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9ef52982-e32d-4d13-bbf5-fe6d766fb57e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2de75311-9177-406d-9fba-12e3650f3f0e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73f2394b-ee4a-4914-92d5-3a16a40b78af"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Booster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b3f7c96-6378-4f6e-a077-2a56214517f2"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReSpawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f871fdb-a4f7-40b1-b91a-8c8ba5bcfcc5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SubAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Floor
        m_Floor = asset.FindActionMap("Floor", throwIfNotFound: true);
        m_Floor_Move = m_Floor.FindAction("Move", throwIfNotFound: true);
        m_Floor_Attack = m_Floor.FindAction("Attack", throwIfNotFound: true);
        m_Floor_Booster = m_Floor.FindAction("Booster", throwIfNotFound: true);
        m_Floor_ReSpawn = m_Floor.FindAction("ReSpawn", throwIfNotFound: true);
        m_Floor_SubAttack = m_Floor.FindAction("SubAttack", throwIfNotFound: true);
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

    // Floor
    private readonly InputActionMap m_Floor;
    private List<IFloorActions> m_FloorActionsCallbackInterfaces = new List<IFloorActions>();
    private readonly InputAction m_Floor_Move;
    private readonly InputAction m_Floor_Attack;
    private readonly InputAction m_Floor_Booster;
    private readonly InputAction m_Floor_ReSpawn;
    private readonly InputAction m_Floor_SubAttack;
    public struct FloorActions
    {
        private @Console m_Wrapper;
        public FloorActions(@Console wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Floor_Move;
        public InputAction @Attack => m_Wrapper.m_Floor_Attack;
        public InputAction @Booster => m_Wrapper.m_Floor_Booster;
        public InputAction @ReSpawn => m_Wrapper.m_Floor_ReSpawn;
        public InputAction @SubAttack => m_Wrapper.m_Floor_SubAttack;
        public InputActionMap Get() { return m_Wrapper.m_Floor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FloorActions set) { return set.Get(); }
        public void AddCallbacks(IFloorActions instance)
        {
            if (instance == null || m_Wrapper.m_FloorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FloorActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Booster.started += instance.OnBooster;
            @Booster.performed += instance.OnBooster;
            @Booster.canceled += instance.OnBooster;
            @ReSpawn.started += instance.OnReSpawn;
            @ReSpawn.performed += instance.OnReSpawn;
            @ReSpawn.canceled += instance.OnReSpawn;
            @SubAttack.started += instance.OnSubAttack;
            @SubAttack.performed += instance.OnSubAttack;
            @SubAttack.canceled += instance.OnSubAttack;
        }

        private void UnregisterCallbacks(IFloorActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Booster.started -= instance.OnBooster;
            @Booster.performed -= instance.OnBooster;
            @Booster.canceled -= instance.OnBooster;
            @ReSpawn.started -= instance.OnReSpawn;
            @ReSpawn.performed -= instance.OnReSpawn;
            @ReSpawn.canceled -= instance.OnReSpawn;
            @SubAttack.started -= instance.OnSubAttack;
            @SubAttack.performed -= instance.OnSubAttack;
            @SubAttack.canceled -= instance.OnSubAttack;
        }

        public void RemoveCallbacks(IFloorActions instance)
        {
            if (m_Wrapper.m_FloorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFloorActions instance)
        {
            foreach (var item in m_Wrapper.m_FloorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FloorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FloorActions @Floor => new FloorActions(this);
    public interface IFloorActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnBooster(InputAction.CallbackContext context);
        void OnReSpawn(InputAction.CallbackContext context);
        void OnSubAttack(InputAction.CallbackContext context);
    }
}
