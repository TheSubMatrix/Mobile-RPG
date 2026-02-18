using UnityEngine;
using UnityEngine.Events;

public class InteractionNotifier : MonoBehaviour, IInteractionSource
{
    [field:SerializeField] public UnityEvent OnInteract { get; set; } = new();

    public void Notify()
    {
        OnInteract.Invoke();
    }
}
