using UnityEngine;

public class InteractableTest : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactor)
    {
        Debug.Log(interactor.name);
    }
}
