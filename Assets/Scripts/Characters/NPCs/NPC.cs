using System;
using System.Collections.Generic;
using MatrixUtils.Attributes;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeReference, ClassSelector] INPCCommand m_currentInteractionCommand;
    [SerializeField] List<NPCCommandSwapRequest> m_commandSwapRequests;
    void Awake()
    {
        foreach (NPCCommandSwapRequest swapRequest in m_commandSwapRequests)
        {
            swapRequest.Initialize(this);
        }
    }
    [Serializable]
    class NPCCommandSwapRequest
    {
        public void Initialize(NPC npc)
        {
            m_changeRequest.OnEventRaised += () => npc.m_currentInteractionCommand = InteractionCommand;
        }
        [SerializeField] VoidEventChannel m_changeRequest;
        [SerializeReference, ClassSelector] public INPCCommand InteractionCommand;
    }   
    public void Interact(GameObject interacted, GameObject interactor)
    {
        m_currentInteractionCommand.Execute(interacted,interactor);
    }
}