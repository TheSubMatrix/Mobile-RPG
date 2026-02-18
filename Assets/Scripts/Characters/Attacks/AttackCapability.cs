using System;
using UnityEngine;

[Serializable]
public class AttackCapability : ICapability
{
    [SerializeField] InterfaceReference<IAttackSource>  m_source;
    [SerializeField] InterfaceReference<IAttackHandler> m_handler;
    public void Initialize()
    {
        m_source.Value.OnAttack.AddListener(m_handler.Value.Attack);
    }

    public void Cleanup()
    {
        m_source.Value.OnAttack.RemoveListener(m_handler.Value.Attack);
    }
}
