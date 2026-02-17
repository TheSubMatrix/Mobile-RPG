using System;
using UnityEngine;
using UnityEngine.Events;
///<summary>
/// Moves the character based on input from the <see cref="ICharacterController"/>
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IPossessable
{
    [Header("Events")]
    [field:SerializeField] public UnityEvent<ICharacterController> OnPossess { get; set; }
    [field:SerializeField] public UnityEvent<ICharacterController> OnUnPossess { get; set; }
    [Header("Controller Options")]
    [SerializeField] float m_movementSpeed = 10f;
    Rigidbody2D m_rigidbody;
    ICharacterController IPossessable.CurrentPossessor { get; set; }
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void IPossessable.Move(Vector2 direction)
    {
        m_rigidbody.linearVelocity = direction * m_movementSpeed;
    }
    void IPossessable.Attack()
    {
        throw new System.NotImplementedException();
    }
}