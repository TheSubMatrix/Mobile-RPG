using UnityEngine;
using UnityEngine.Events;

public class InteractableHandler : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent<GameObject> m_onInteract = new UnityEvent<GameObject>();
    public void Interact(GameObject interactor)
    {
        m_onInteract.Invoke(interactor);
    }
}
