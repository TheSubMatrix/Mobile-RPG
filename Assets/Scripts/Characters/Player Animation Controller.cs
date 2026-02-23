
using UnityEngine;
[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] string m_speedParameter = "speed";
    [SerializeField] string m_verticalMovement = "verticalMovement";
    [SerializeField] string m_horizontalMovement = "horizontalMovement";
    Animator m_animator;
    Rigidbody2D m_rigidbody;
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        m_animator.SetFloat(m_verticalMovement, Vector2.Dot(Vector2.up, m_rigidbody.linearVelocity.normalized));
        m_animator.SetFloat(m_horizontalMovement, Vector2.Dot(Vector2.right, m_rigidbody.linearVelocity.normalized));
        m_animator.SetFloat(m_speedParameter, m_rigidbody.linearVelocity.magnitude);
    }
}
