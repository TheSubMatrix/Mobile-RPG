using System;
using UnityEngine;

[Serializable]
public class InteractionCapability : ICapability
{
    [SerializeField] InterfaceReference<IInteractionSource>  m_source;
    [SerializeField] InterfaceReference<IInteractionHandler> m_handler;
    public void Initialize()
    {
        m_source.Value.OnInteract.AddListener(m_handler.Value.Interact);
    }

    public void Cleanup()
    {
        m_source.Value.OnInteract.RemoveListener(m_handler.Value.Interact);
    }
}
