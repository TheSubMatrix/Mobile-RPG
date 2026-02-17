using UnityEngine;
using UnityEngine.Events;
public interface ICharacterControllerMover
{
    public UnityEvent<Vector2> OnMove { get; }
}
