using UnityEngine;
using UnityEngine.Events;

public interface IInteractionSource
{
    public UnityEvent OnInteract{ get; }
}
