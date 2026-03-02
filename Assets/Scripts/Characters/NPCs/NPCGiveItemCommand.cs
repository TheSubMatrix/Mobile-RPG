using System;
using UnityEngine;
[Serializable]
public class NPCGiveItemCommand : INPCCommand
{
    [SerializeField] uint m_amountToGive;
    [SerializeField] ItemSO m_itemToGive;
    public void Execute(GameObject interacted, GameObject executionRequester)
    {
        if (!executionRequester.TryGetComponent(out Inventory inventory)) { return; }
        inventory.TryAddItem(m_itemToGive, m_amountToGive);
    }
}
