using UnityEngine;
using VContainer.Unity;

public class PlayerMovePresenter : ITickable
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

    public void Tick()
    {
        float currentTime = Time.time;
        Vector2 moveInput = _input.GetMoveInput();

        if (_input.GetDashInput() && _model.CanDash(currentTime))
        {
            StartDash(currentTime);
        }

        if (_isDashing)
        {
            _dashTimer -= Time.deltaTime;
            if (_dashTimer <= 0) EndDash();
        }
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
