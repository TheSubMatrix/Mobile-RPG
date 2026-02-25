using MatrixUtils.Attributes;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeReference, ClassSelector] public INPCCommand InteractionCommand;
    public void Interact(GameObject interacted, GameObject interactor)
    {
        InteractionCommand.Execute(interacted,interactor);
    }
}