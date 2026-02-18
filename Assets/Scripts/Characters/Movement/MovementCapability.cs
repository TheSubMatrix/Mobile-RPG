using System;
using UnityEngine;

[Serializable]
public class MovementCapability : ICapability
{
    [SerializeField] InterfaceReference<IMovementSource> m_source;
    [SerializeField] InterfaceReference<IMovementHandler> m_handler;
    public void Initialize()
    {
        m_source.Value.OnMove.AddListener(m_handler.Value.Move);
    }

    public void Cleanup()
    {
        m_source.Value.OnMove.RemoveListener(m_handler.Value.Move);
    }
}