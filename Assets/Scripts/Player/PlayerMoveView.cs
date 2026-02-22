using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveView : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer dashTrail;

    public void SetVelocity(Vector2 velocity)
    {
        rb.linearVelocity = velocity;
    }

    public void SetDashVisual(bool active)
    {
        if (dashTrail != null) 
        {
            dashTrail.emitting = active;
        }
    }
}
