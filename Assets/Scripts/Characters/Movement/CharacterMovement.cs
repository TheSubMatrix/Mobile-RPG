using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour, IMovementHandler
{
    Rigidbody2D m_rb;
    [SerializeField] float m_speed = 5;
    void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 direction)
    {
        m_rb.linearVelocity = direction * m_speed;
    }
}
