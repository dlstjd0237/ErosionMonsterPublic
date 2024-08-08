using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(menuName = "SO/Input")]
public class InputReader : ScriptableObject, Console.IFloorActions
{
    public float InputY { get; private set; }

    public event Action<bool> AttackEvent;
    public event Action<bool> BoosterEvent;
    public event Action ReSpawnEvent;
    public event Action SubAttackEvent;

    private Console _console;
    public Console Console => _console;
    private void OnEnable()
    {
        if (_console == null)
        {
            _console = new Console();
            _console.Floor.SetCallbacks(this);
        }
        _console.Floor.Enable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AttackEvent?.Invoke(true);
        }
        else if (context.action.WasReleasedThisFrame())
        {
            AttackEvent?.Invoke(false);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        InputY = context.ReadValue<Vector2>().y;
    }

    public void OnBooster(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            BoosterEvent?.Invoke(true);
        }
        else if (context.action.WasReleasedThisFrame())
        {
            BoosterEvent?.Invoke(false);
        }
    }

    public void OnReSpawn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ReSpawnEvent?.Invoke();
        }
    }

    public void OnSubAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            SubAttackEvent?.Invoke();
    }
}
