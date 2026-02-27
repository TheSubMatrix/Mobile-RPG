using UnityEngine;
using UnityEngine.Events;

public class InteractableHandler : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent<GameObject, GameObject> m_onInteract = new();
    public void Interact(GameObject self,GameObject interactor)
    {
        m_onInteract.Invoke(gameObject, interactor);
    }
}
