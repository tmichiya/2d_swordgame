using UnityEngine;

public class PlayerMoveModel
{
    private readonly PlayerStats _stats;
    private float _lastDashTime = -99f;

    public PlayerMoveModel(PlayerStats stats)
    {
        _stats = stats;
    }

    public bool CanDash(float currentTime)
    {
        return currentTime >= _lastDashTime + _stats.dashCooldown;
    }

    public void RecordDashTime(float currentTime)
    {
        _lastDashTime = currentTime;
    }

    public Vector2 CalculateVelocity(Vector2 input, bool isDashing)
    {
        float speed;
        if (isDashing == true)
        {
            speed = _stats.dashSpeed;
        } 
        else
        {
            speed = _stats.moveSpeed;
        }

        return input * speed;
    }
}
