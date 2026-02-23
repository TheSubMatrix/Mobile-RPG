using MatrixUtils.Attributes;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeReference, ClassSelector] INPCCommand m_interactionCommand;
    public void Interact(GameObject interactor)
    {
        m_interactionCommand.Execute(interactor);
        m_interactionCommand = new EmptyNPCCommand();
    }
}