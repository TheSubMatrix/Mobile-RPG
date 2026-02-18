using UnityEngine;
using UnityEngine.Events;

public interface IMovementSource
{
    UnityEvent<Vector2> OnMove { get; }
}