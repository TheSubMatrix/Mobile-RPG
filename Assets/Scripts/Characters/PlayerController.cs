using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Handles the input from the player via events and calls the appropriate methods on the <see cref="IPossessable"/> that this <see cref="ICharacterController"/> is possessing
/// </summary>
public class PlayerController : MonoBehaviour, ICharacterController
{
    [field:SerializeField] public UnityEvent<Vector2> OnMove { get; private set; } = new();
    [field:SerializeField] public UnityEvent OnAttack { get; private set; } = new();
    [SerializeField] InterfaceReference<IPossessable> StartingPossessable;
    public void Move(Vector2 direction) => OnMove.Invoke(direction);
    public void Attack() => OnAttack.Invoke();
    void OnEnable() => StartingPossessable.Value?.Possess(this);
    void OnDisable() => StartingPossessable.Value?.UnPossess(this);
}