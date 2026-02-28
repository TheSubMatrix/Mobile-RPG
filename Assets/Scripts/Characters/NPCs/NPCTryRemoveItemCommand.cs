using System;
using MatrixUtils.Attributes;
using UnityEngine;
using UnityEngine.Serialization;
[Serializable]
public class NPCTryRemoveItemCommand : INPCCommand
{
    [SerializeField] uint m_requiredAmount;
    [SerializeField] ItemSO m_itemToCheck;
    [SerializeReference, ClassSelector] INPCCommand m_checkSuccessCommand;
    [SerializeReference, ClassSelector] INPCCommand m_checkFailureCommand;
    public void Execute(GameObject interacted, GameObject executionRequester)
    {
        if (!executionRequester.TryGetComponent(out Inventory inventory)) return;
        if (inventory.TryRemoveItem(m_itemToCheck, m_requiredAmount) <= 0)
        {
            m_checkSuccessCommand.Execute(interacted, executionRequester);
        }
        else
        {
            m_checkFailureCommand.Execute(interacted, executionRequester);
        }
    }
}
