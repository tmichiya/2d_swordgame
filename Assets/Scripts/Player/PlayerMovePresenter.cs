using NUnit.Framework;
using UnityEngine;
using VContainer.Unity;

public class PlayerMovePresenter : ITickable, IStartable
{
    private readonly PlayerMoveModel _model;
    private readonly PlayerMoveView _view;
    private readonly IInputProvider _input;
    private readonly PlayerStats _stats;

    private float _dashTimer;
    private bool _isDashing;

    public PlayerMovePresenter(PlayerMoveModel model, PlayerMoveView view, IInputProvider input, PlayerStats stats)
    {
        _model = model;
        _view = view;
        _input = input;
        _stats = stats;
    }

    public void Start()
    {
        _view.SetDashVisual(false);
    }

    public void Tick()
    {
        float currentTime = Time.time;
        Vector2 moveInput = _input.GetMoveInput();

        if (moveInput != Vector2.zero)
        {
            Debug.Log("test");
        }

        if (_input.GetDashInput() && _model.CanDash(currentTime))
        {
            StartDash(currentTime);
        }

        if (_isDashing)
        {
            _dashTimer -= Time.deltaTime;
            if (_dashTimer <= 0) EndDash();
        }

        var velocity = _model.CalculateVelocity(moveInput, _isDashing);
        _view.SetVelocity(velocity);
    }

    private void StartDash(float time)
    {
        _isDashing = true;
        _dashTimer = _stats.dashDuration;
        _model.RecordDashTime(time);
        _view.SetDashVisual(true);
    }

    private void EndDash()
    {
        _isDashing = false;
        _view.SetDashVisual(false);
    }
}
