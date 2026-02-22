using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputProvider : IInputProvider, IDisposable
{
    private readonly GameInputs _inputs;
    public PlayerInputProvider()
    {
        _inputs = new GameInputs();
        _inputs.Player.Enable();
    }

    public Vector2 GetMoveInput()
    {
        return _inputs.Player.Move.ReadValue<Vector2>();
    }

    public bool GetDashInput()
    {
        return _inputs.Player.Dash.WasPressedThisFrame();
    }

    public void Dispose()
    {
        _inputs.Player.Disable();
        _inputs.Dispose();
    }
}
